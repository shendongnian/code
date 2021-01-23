    public double? ConvertStringToDouble(string strDoubleValue)
    {
        //Checking null
        if (strDoubleValue == null)
        {
            return null;
        }
        //Making trim
        strDoubleValue = strDoubleValue.Trim();
        //Checking empty
        if (strDoubleValue == string.Empty)
        {
            return null;
        }
         
        //If the amout treat dot(.) as decimal separator
        if (strDoubleValue.IndexOf('.')!=-1)
        {
            //If multiple . is present then the amount is invaid
            if (strDoubleValue.Count(o=>o=='.')>1)
            {
	            return null;
            }
            //removing thousand separators
            //it might not be needed
            strDoubleValue = strDoubleValue.Replace(",", "");
            return ConvertPlainStringToDouble(strDoubleValue);
        }
        //If the amout treat dot(,) as decimal separator
        //then it must not use ',' as thousand separator
        if (strDoubleValue.Count(o => o == ',') > 1)
        {
            //removing thousand separators
            //it might not be needed
            strDoubleValue = strDoubleValue.Replace(",", "");
            return ConvertPlainStringToDouble(strDoubleValue);                
        }
        //Here will be logic that the string contains single comma , is treated here as 
        //deciaml separator or comma separator
       
        //int charCountBeforeComma = strDoubleValue.IndexOf(',');
        //int charCountAfterComma = strDoubleValue.Length - (charCountBeforeComma + 1);
        ////If charCountAfterComma is not in 3rd position than
        ////the comma cannot be thousand separator example: 458,5896
        //if (charCountAfterComma!=3)
        //{
        //    //removing thousand separators
        //    //it might not be needed
        //    strDoubleValue = strDoubleValue.Replace(",", ".");
        //    return ConvertPlainStringToDouble(strDoubleValue);   
        //}
        //if string having more than 3 char before comma like 4589,548
        //it means no thousand separator used else the amount should represent like this 4,589,548
        //you can use below code 
        //if (charCountBeforeComma>3)
        //{
        //    //removing thousand separators
        //    //it might not be needed
        //    strDoubleValue = strDoubleValue.Replace(",", "");
        //    return ConvertPlainStringToDouble(strDoubleValue);   
        //}
        
        //if all above missed than i am sorry              
        //it means the string is like 458,458 or 58,458 format
        //you need to put some logical condition here 
        //??????
    }
    private Double? ConvertPlainStringToDouble(string strPlainDoubleValue)
    {            
        Double amount;
        if (Double.TryParse(strPlainDoubleValue, out amount))
        {
            return amount;
        }
        return null;
    }
