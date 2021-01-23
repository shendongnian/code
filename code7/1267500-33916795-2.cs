    private void butConnect_Click(object sender, EventArgs e)
        {
            SocketHandler.Instance.Connect("192.168.0.1");
        }
        private void butSend_Click(object sender, EventArgs e)
        {
            string msg = txtMessage.Text;
            SocketHandler.Instance.Send(msg);
            txtMessage.Clear();
        }
