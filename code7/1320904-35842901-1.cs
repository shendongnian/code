        private void SetPicture(System.Drawing.Image img, string label)
        {
            if (pbOutput.InvokeRequired)
            {
                pbOutput.Invoke(new MethodInvoker(
                delegate()
                {
                    pbOutput.Image = img;
                    pbOutput.Refresh();
                    Thread.Sleep(Interval);
                }));
            }
            else
            {
                pbOutput.Image = img;
                pbOutput.Invalidate();
                Thread.Sleep(Interval);
            }
        }
