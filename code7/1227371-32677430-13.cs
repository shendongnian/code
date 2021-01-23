    private void btn_Click(object sender, EventArgs e)
    {
        //Note: ideally, curCulture shouldn't be defined here (but globally or  
        //passed as argument), but otherwise my code would be somehow incomplete.
        CultureInfo curCulture = new CultureInfo("en-US", true);
    
        bool isOK = false;
        string[] temp = totalTextBox.Text.Trim().Split(new string[] { curCulture.NumberFormat.CurrencySymbol }, StringSplitOptions.None);
        if (temp.Length == 2 && temp[0].Trim().Length == 0)
        {
            isOK = isDecimalOK(temp[1], curCulture);
        }
    
        MessageBox.Show(isOK ? "currency format" : "error wrong format");
    }
    
    private bool isDecimalOK(string inputString, CultureInfo curCulture)
    {
        string[] temp = inputString.Split(new string[] { curCulture.NumberFormat.CurrencyDecimalSeparator }, StringSplitOptions.None);   
        if(temp.Length > 2) return false;
        for(int i = 0; i < temp.Length; i++)
        {
            int outVal0 = 0;
            if (!int.TryParse(temp[i], (i == 0 ? NumberStyles.AllowThousands : NumberStyles.Integer), curCulture, out outVal0)) return false;
            else return analyseThousands(temp[i], curCulture);
        }
    
        return true;
    }
    
    private bool analyseThousands(string intInput, CultureInfo curCulture)
    {
        
        string[] temp2 = intInput.Split(new string[] { curCulture.NumberFormat.CurrencyGroupSeparator }, StringSplitOptions.None);
        
        if (temp2.Length >= 2)
        {
            if (temp2[0].Trim().Length == 0) return false;
            else
            {
                for (int i2 = 1; i2 < temp2.Length; i2++)
                {
                    if (!curCulture.NumberFormat.CurrencyGroupSizes.Contains(temp2[i2].Length)) return false;
                }
            }
        }
    
        return true;
    }
