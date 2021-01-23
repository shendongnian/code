    private void btn_Click(object sender, EventArgs e)
    {
    
        bool isOK = false;
        string[] temp = totalTextBox.Text.Trim().Split(new string[] { curCulture.NumberFormat.CurrencySymbol }, StringSplitOptions.None);
        if (temp.Length == 2 && temp[0].Trim().Length == 0)
        {
            decimal outVal = 0m;
            if (decimal.TryParse(temp[1], out outVal)) isOK = true;
        }
    
        MessageBox.Show(isOK ? "currency format" : "error wrong format");
    
    }
