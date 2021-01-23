    internal class PcscWrapper : IDisposable
    {
        private SCardMonitor pcscMonitor;
        private string lastUniqueId;
        private NfcEventType lastEventType;
        public string[] ReaderNames { get; private set; }
        internal event EventHandler<NfcEventArgs> PcScNfcEventReceived;
        internal bool CheckReaders()
        {
            using (var context = new SCardContext())
            {
                context.Establish(SCardScope.System);
                ReaderNames = context.GetReaders();                
                context.Release();
            }
            if (ReaderNames == null || ReaderNames.Length < 1)
            {
                Debug.WriteLine("PcscWrapper: No readers installed.");
                return false;
            }
            return true;
        }
        internal bool Initialize(out NfcDeviceType type)
        {
            type = NfcDeviceType.None;
           
            // Start Pcsc
            pcscMonitor = new SCardMonitor(ContextFactory.Instance, SCardScope.System);            
            pcscMonitor.MonitorException += (s, a) => OnPcScExceptionReceived(s, a);
            pcscMonitor.StatusChanged += (s, a) => OnPcScStatusChangeEventReceived(s, a);
            pcscMonitor.CardInserted += (s, a) => OnPcScCardStatusEventReceived(s, a);
            pcscMonitor.CardRemoved += (s, a) => OnPcScCardStatusEventReceived(s, a);
            foreach (var reader in ReaderNames)
            {
                Debug.WriteLine("PcscWrapper: Init Listening on reader " + reader + ".");
            }
            pcscMonitor.Start(ReaderNames);
            type = NfcDeviceType.Pcsc;
            return true;
        }
        private void OnPcScExceptionReceived(object s, PCSCException a)
        {
            var eventargs = new NfcEventArgs();
            eventargs.Type = NfcEventType.Unknown;            
            eventargs.Data = $"Error: {a.Message} ({a.SCardError.ToString()})";
            PcScNfcEventReceived?.Invoke(this, eventargs);
        }
        private void OnPcScStatusChangeEventReceived(object s, StatusChangeEventArgs a)
        {
            RaisePcScEvent(a.NewState, a.ReaderName);            
        }
        private void OnPcScCardStatusEventReceived(object s, CardStatusEventArgs a)
        {
            RaisePcScEvent(a.State, a.ReaderName);
        }
        private void RaisePcScEvent(SCRState state, string readerName)
        {
            bool doRaiseEvent = true;
            var eventargs = new NfcEventArgs();
            eventargs.ReaderName = readerName;
            eventargs.Data = $"New State for {readerName}: {state.ToString()}";
            switch (state)
            {
                case SCRState.Changed:
                    eventargs.Type = NfcEventType.StatusChanged;
                    break;
                case SCRState.Empty:
                case SCRState.Unavailable:
                    eventargs.Type = NfcEventType.Disconnected;
                    lastUniqueId = null;
                    break;
                case SCRState.Present:
                    eventargs.Type = NfcEventType.Connected;
                    eventargs.UniqueCardID = state.CardIsPresent() ? GetUid(readerName) : null;
                    if (eventargs.UniqueCardID == lastUniqueId)
                    {
                        doRaiseEvent = false;
                    }
                    break;
                case SCRState.Unknown:
                    eventargs.Type = NfcEventType.Unknown;
                    break;
                default:
                    doRaiseEvent = false;
                    break;
            }
            if (doRaiseEvent && lastEventType != eventargs.Type)
            {
                string debugText = $"PcscWrapper: {eventargs.Type.ToString()} UID: ";
                debugText += eventargs.UniqueCardID ?? "N/A";
                Debug.WriteLine(debugText);
                System.Threading.Thread.Sleep(200);
                PcScNfcEventReceived?.Invoke(this, eventargs);
                lastUniqueId = eventargs.UniqueCardID;
                lastEventType = eventargs.Type;
            }
        }
        private string GetUid(string readerName)
        {
            using (var context = new SCardContext())
            {
                context.Establish(SCardScope.System);
                using (var rfidReader = new SCardReader(context))
                {
                    var sc = rfidReader.Connect(readerName, SCardShareMode.Shared, SCardProtocol.Any);
                    if (sc != SCardError.Success)
                    {
                        Debug.WriteLine($"PcscWrapper: Could not connect to reader {readerName}:\n{SCardHelper.StringifyError(sc)}");
                        return null;
                    }
                    var apdu = new CommandApdu(IsoCase.Case2Short, rfidReader.ActiveProtocol)
                    {
                        CLA = 0xFF,
                        Instruction = InstructionCode.GetData,
                        P1 = 0x00,
                        P2 = 0x00,
                        Le = 0  // We don't know the ID tag size
                    };
                    sc = rfidReader.BeginTransaction();
                    if (sc != SCardError.Success)
                    {
                        Debug.WriteLine("PcscWrapper: Could not begin transaction.");
                        return null;
                    }                    
                    var receivePci = new SCardPCI(); // IO returned protocol control information.
                    var sendPci = SCardPCI.GetPci(rfidReader.ActiveProtocol);
                    var receiveBuffer = new byte[256];
                    var command = apdu.ToArray();
                    sc = rfidReader.Transmit(
                        sendPci,            // Protocol Control Information (T0, T1 or Raw)
                        command,            // command APDU
                        receivePci,         // returning Protocol Control Information
                        ref receiveBuffer); // data buffer
                    if (sc != SCardError.Success)
                    {
                        Debug.WriteLine("Error: " + SCardHelper.StringifyError(sc));
                    }
                    var responseApdu = new ResponseApdu(receiveBuffer, IsoCase.Case2Short, rfidReader.ActiveProtocol);
                    rfidReader.EndTransaction(SCardReaderDisposition.Leave);
                    rfidReader.Disconnect(SCardReaderDisposition.Reset);
                    if (responseApdu.HasData)
                    {
                        string uid = BitConverter.ToString(responseApdu.GetData()).Replace("-", "").ToUpper();
                        return (uid);
                    }
                }
            }
            return null;
        }
        public void Dispose()
        {
            if (pcscMonitor != null)
            {
                if (pcscMonitor.Monitoring)
                {
                    pcscMonitor.Cancel();
                }
                pcscMonitor.Dispose();
            }
        }
    }
