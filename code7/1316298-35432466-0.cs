        static void Main(string[] args)
        {
            FsMomitorIPCCarier data = new FsMomitorIPCCarier("someData");
            IpcAccessorSetting curSrv = new IpcAccessorSetting(IPChannelS.FsMonitor, IpcAccessorThreadNameS.FsmonitorThrd, 0, 2000);
            MMFDepositT FsMonitorSetterDepo = null;
            try
            {
                FsMonitorSetterDepo = new MMFDepositT(curSrv.Channel.ToString(),curSrv.AccThreadName.ToString(), 4096);
     
                FsMonitorSetterDepo.ReadPosition = curSrv.AccessorSectorsSets.DepoSects.Setter.Read;
                FsMonitorSetterDepo.WritePosition =curSrv.AccessorSectorsSets.DepoSects.Setter.Write;
                Console.WriteLine("MonitorSetterDepo.ReadPosition " + FsMonitorSetterDepo.ReadPosition);
                Console.WriteLine("MonitorSetterDepo.WritePosition " + FsMonitorSetterDepo.WritePosition);
                FsMonitorSetterDepo.DataReceived += new EventHandler<MemoryMappedDataReceivedEventArgs>(FsMonitorSetter_DataReceived);
                FsMonitorSetterDepo.StartReader();
            }
            catch (Exception e)
            {
               Console.ForegroundColor = ConsoleColor.Red;
               Console.WriteLine("MonitorSetterDepo ctor: " + e.Message);
            }
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("MonitorSetterDepo is now online");
            var msg = data.DipositStrVal.StrValue.Val;
            Console.WriteLine("Data = " + msg);
            bool quit = false;
            while (!quit)
            {
                Console.ReadLine();
                if (!string.IsNullOrEmpty(msg))
                {
                    var dataDelvr = data.IpcCarierToByteArray();
                    FsMonitorSetterDepo.Write(dataDelvr);
                }
                else
                {
                    quit = true;
                }
                //msg = "";
            }
            //DepoTest.statusSet.ForEach(SttM => Console.WriteLine(SttM));
                   
            FsMonitorSetterDepo.Close();
            FsMonitorSetterDepo = null;
        }
