    if (!String.IsNullOrEmpty(textBox3.Text) && !String.IsNullOrEmpty(textBox4.Text))
    {
        var client = new ClientService();
        client.ClientName = textBox4.Text;
        client.ServerIp = textBox3.Text;
        client.Connect();
    }
    else
    {
        MessageBox.Show("Fill it completely");
    }
