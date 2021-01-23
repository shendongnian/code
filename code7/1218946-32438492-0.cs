        public void retry()
        {
            Thread beepThread = new Thread(new ThreadStart(PlayBeep));
            beepThread.IsBackground = true;
            beepThread.Start();
            if (MessageBox.Show("Item not found", "Alert", MessageBoxButtons.RetryCancel) == DialogResult.Retry)
            {
                beepThread.Abort();
                retry();
            }
            else
            {
                beepThread.Abort();
                Console.Beep(500, 1);
                return;
            }
        }
        private void PlayBeep()
        {
            while(true)
               { Console.Beep(500, int.MaxValue); }
        }
