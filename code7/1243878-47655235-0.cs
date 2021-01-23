    // sample calling code
    Console.WriteLine(EuropeanVatInformation.Get("FR89831948815"));
    ...
    public class EuropeanVatInformation
    {
        private EuropeanVatInformation() { }
        public string CountryCode { get; private set; }
        public string VatNumber { get; private set; }
        public string Address { get; private set; }
        public string Name { get; private set; }
        public override string ToString() => CountryCode + " " + VatNumber + ": " + Name + ", " + Address.Replace("\n", ", ");
        public static EuropeanVatInformation Get(string countryCodeAndVatNumber)
        {
            if (countryCodeAndVatNumber == null)
                throw new ArgumentNullException(nameof(countryCodeAndVatNumber));
            if (countryCodeAndVatNumber.Length < 3)
                return null;
            return Get(countryCodeAndVatNumber.Substring(0, 2), countryCodeAndVatNumber.Substring(2));
        }
        public static EuropeanVatInformation Get(string countryCode, string vatNumber)
        {
            if (countryCode == null)
                throw new ArgumentNullException(nameof(countryCode));
            if (vatNumber == null)
                throw new ArgumentNullException(nameof(vatNumber));
            countryCode = countryCode.Trim();
            vatNumber = vatNumber.Trim().Replace(" ", string.Empty);
            const string url = "http://ec.europa.eu/taxation_customs/vies/services/checkVatService";
            const string xml = @"<s:Envelope xmlns:s='http://schemas.xmlsoap.org/soap/envelope/'><s:Body><checkVat xmlns='urn:ec.europa.eu:taxud:vies:services:checkVat:types'><countryCode>{0}</countryCode><vatNumber>{1}</vatNumber></checkVat></s:Body></s:Envelope>";
            try
            {
                using (var client = new WebClient())
                {
                    var doc = new XmlDocument();
                    doc.LoadXml(client.UploadString(url, string.Format(xml, countryCode, vatNumber)));
                    var response = doc.SelectSingleNode("//*[local-name()='checkVatResponse']") as XmlElement;
                    if (response == null || response["valid"]?.InnerText != "true")
                        return null;
                    var info = new EuropeanVatInformation();
                    info.CountryCode = response["countryCode"].InnerText;
                    info.VatNumber = response["vatNumber"].InnerText;
                    info.Name = response["name"]?.InnerText;
                    info.Address = response["address"]?.InnerText;
                    return info;
                }
            }
            catch
            {
                return null;
            }
        }
    }
