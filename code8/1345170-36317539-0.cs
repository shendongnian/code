    protected void ShowRawData(string[] rawData)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < rawData.Length; ++i)
        {
            sb.AppendLine(rawData[i]);
        }
        TextBox1.Text = sb.ToString();
    }
