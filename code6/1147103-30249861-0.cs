        private void runTask() {
            //Process here....
            timer1.Enabled = false;
            System.Threading.Thread.Sleep(100);
            MessageBox.Show(timer1.Enabled.ToString());
        }
