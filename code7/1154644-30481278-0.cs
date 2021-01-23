    private async void button2_Click(object sender, EventArgs e)
    {
        // ...
        if (i != 1)
        {
            await Task.Run(() => sendMail("QueryReport.pdf", "4POS StockItem/per price list Query Report"));
        }
        // ...
    }
