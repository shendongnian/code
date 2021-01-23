    private void InfoSend_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(3000);
        input_info = input_info.Replace(" ", string.Empty);
        SendKeys.Send(input_info);
    }
