    using (System.IO.StreamWriter writer = new System.IO.StreamWriter(@"" + textBox2.Text + @"\" + filename.TrimStart() + ".csv", true))  
    
    {
    
        if (!exists)
        {
            writer.WriteLine(DateTime.Now.ToLongDateString());
            writer.WriteLine("REG.,BR.,BR.NAME,AC TYPE,PRODUCT,NO.OF ACS,ORG.CURRENCY BALANCE,ORG CURRENCY,BALANCE LKR");
        }
        var textArray = text.Replace("|", ",").split(Environment.NewLine);
        int number = 0;
      
        foreach (string text in textArray)
        {
            number ++;
            write.WriteLine(text + "," + number.ToString());
        }
