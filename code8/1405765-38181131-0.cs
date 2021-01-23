        public string inputread => plc.InputImage[1].ToString();
        void threadFunc()
        {
            try
            {
                while (threadRunning)
                {
                    plc.Read();
                    inputread = plc.InputImage[1].ToString();
                    Dispatcher.Invoke(() => OnPropertyChanged(nameof(inputread)));
                }
            }
            catch (ThreadAbortException)
            {
            }
        }
