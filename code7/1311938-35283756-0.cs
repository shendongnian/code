    public class FundingSource {
    public int ClientAccountPaySource {get; set;}
    public int ClientAccountId {get; set;}
    public string ClientAccountName {get; set;}
    ...
    }
    //Use it like so:
    System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(p.GetType());
    
    x.Serialize(Console.Out, new FundingSource() { ClientAccountPaySource=1, ClientAccountId=100, ClientAccountName="Name"});
