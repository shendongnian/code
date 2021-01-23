    public string FormatDate(string param1){
    param1=param1.Replace("\"","");
    param1=param1.Substring(4,4) + '-' + param1.Substring(2,2) + '-' + param1.Substring(0,2) + ' ' + param1.Substring(10,2) + ':' + param1.Substring(12,2);
        
       System.DateTime strDate;
        if (System.DateTime.TryParseExact(param1, "yyyy-MM-dd HH:mm", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None,out strDate))
        {
            return strDate.ToString("yyyy-MM-ddThh:mm:ss");
        }
        return "INVALID DATE";
    }enter code here`
