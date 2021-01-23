    delegate void ProgressMessageCallback(string message);
        private void ProgressMessage(string message)
        {
            if (InvokeRequired)
            {
                ProgressMessageCallback d = new ProgressMessageCallback(ProgressMessage);
                this.Invoke(d, new object[] { message });
            }
            else
            {
                this.lblProgressMessage.Text = message;
            }
        }
