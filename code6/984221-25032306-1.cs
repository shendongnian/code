    class MyForm : Form
    {
        public void ShowMessage(string msg)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(ShowMessage, msg));
                return;
            }
            
            this.messageTextBox.Text = msg;
        }
    }
