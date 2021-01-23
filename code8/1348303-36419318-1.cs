    protected void Riesgo_Total_Des_Validate(object source, ServerValidateEventArgs args)
    {
        int lowerNum;
        int higherNum;
        bool lower = int.TryParse(txtRiesgo_Total_Des.Text, out lowerNum);
        bool higher = int.TryParse(txtRiesgo_Total_Has.Text, out higherNum);
        if (lower && higher)
        {
         if (lowerNum >= higherNum)
            {
                args.IsValid = false;
               
            }
          
        }
    }
    
