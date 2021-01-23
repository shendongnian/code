    public class Address
    {
    	public string address_1 { get; set; }
    	public string country { get; set; }
    }
    
    public class Identification
    {
    	public string name { get; set; }
    	public string number { get; set; }
    	public string type { get; set; }
    	public string expiry_date { get; set; }
    	public string place_of_issue { get; set; }
    }
    
    public class Remitter
    {
    	public string name { get; set; }
    	public object first_name { get; set; }
    	public object middle_name { get; set; }
    	public object last_name { get; set; }
    	public object contact_number { get; set; }
    	public object account_number { get; set; }
    	public Address address { get; set; }
    	public Identification identification { get; set; }
    }
    
    public class Beneficiary
    {
    	public string name { get; set; }
    	public object first_name { get; set; }
    	public object middle_name { get; set; }
    	public object last_name { get; set; }
    	public object contact_number { get; set; }
    	public object account_number { get; set; }
    	public Address address { get; set; }
    	public Identification identification { get; set; }
    }
    
    public class PayoutAmount
    {
    	public string currency { get; set; }
    	public string amount { get; set; }
    }
    
    public class Remittance
    {
    	public string transaction_id { get; set; }
    	public string status { get; set; }
    	public string source_reference_number { get; set; }
    	public Remitter remitter { get; set; }
    	public Beneficiary beneficiary { get; set; }
    	public PayoutAmount payout_amount { get; set; }
    	public object remarks { get; set; }
    	public string value_date { get; set; }
    	public string date_created { get; set; }
    }
    
    public class RootObject
    {
    	public string response_code { get; set; }
    	public Remittance remittance { get; set; }
    	public string response_message { get; set; }
    }
