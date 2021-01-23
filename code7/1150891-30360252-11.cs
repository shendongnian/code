    JavaScriptSerializer jss = new JavaScriptSerializer();
    BigDataClass bdc = new BigDataClass();
    bdc.Data.Add("Test String");
    string serd = jss.Serialize(bdc);
    Console.WriteLine(serd);
    BigDataClass bdc2 = jss.Deserialize<BigDataClass>(serd);
