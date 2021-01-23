        delegate void SetTextCallback(bool visible);
        private void SetVisible(bool visible)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetVisible);
                this.Invoke(d, new object[] { visible });
            }
            else
            {
                this.Visible = visible;
            }
        }
