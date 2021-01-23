    Current currents = JsonConvert.DeserializeObject<RootObject>(json_data);     
    public class Current
    {
    public int currentCode { get; set; }
    public string currentName { get; set; }
    public string currentAddress { get; set; }
    public string currentTel { get; set; }
    public string fax { get; set; }
    public string currentProvince { get; set; }
    public string currentCounty { get; set; }
    public string taxOffice { get; set; }
    public string taxNo { get; set; }
    public string currentType { get; set; }
    public string postalCode { get; set; }
    public string countryCode { get; set; }
    public int additionalCurrentCode { get; set; }
    }
     public class RootObject
    {
    public List<Current> currents { get; set; }
     }
