    public delegate void BarcodeRead(string barcode);
    public class ManualReader
    {
        private string barcode = "no barcode detected";
        private string possible = "";
        private DateTime timestarted = DateTime.MinValue;
        private Timer InputTimeout;
        public BarcodeRead OnBarcodeRead;
        public void OnKeyDown(object sender, KeyEventArgs.KeyEventArgs e)
        {
            //create timer if it does not exist
            if (InputTimeout == null)
            {
                InputTimeout = new Timer(100);
                InputTimeout.Enabled = true;
                InputTimeout.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            }
            //reset timer
            InputTimeout.Stop();
            InputTimeout.Start();
            //possible barcode
            possible += CharToKey.GetCharFromKey(e);
            if (timestarted == DateTime.MinValue)
            {
                timestarted = DateTime.Now;
            }
        }
        //Timer elapses
        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            //Is it a barcode?
            if ((timestarted.AddMilliseconds(600) > DateTime.Now) && (possible.Length > 5)
                    && (timestarted != DateTime.MinValue) && possible.Contains("\r"))
            {
                barcode = possible;
                barcode = barcode.Remove(0, 1);
                barcode = barcode.Replace("\r", "");
                //launch delegate
                if (OnBarcodeRead != null)
                {
                    OnBarcodeRead.Invoke(barcode);                    
                }
            }
            //delete timers
            timestarted = DateTime.MinValue;
            InputTimeout.Dispose();
            InputTimeout = null;
            possible = null;
        }
      }
    }
