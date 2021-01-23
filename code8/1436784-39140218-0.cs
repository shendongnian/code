    public partial class Get_CountryInfo_Resp_object
    {
          public string ReturnCode { get; set; }
          ...
          public List<As_SenderCountry> As_SenderCountry { get; set; }
          public List<As_ReceiverCountry> As_ReceiverCountry { get; set; }
    }
    private static void Task2()
    {
          String xmlText = File.ReadAllText(@"../../XML/sample1.xml");
          DataSet ds = new DataSet();
          ds.ReadXml(new XmlTextReader(new StringReader(xmlText)));
    
          DataTable dt = ds.Tables["column"];
    
          Get_CountryInfo_Resp_object Get_CountryInfo_Resp = new Get_CountryInfo_Resp_object();
          ...
          GetCountryInfo_Resp.As_SenderCountry.SenderCountry_IsSensitive.Add(dt.Rows[6]["column_Text"].ToString());
