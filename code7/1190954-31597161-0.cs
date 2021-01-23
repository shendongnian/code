    try
    {
    	using (var client = new HttpClient())
    	{
    		client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "<Replace with your oAuth Token>");
    
    		ContactObject cont = new ContactObject
    		{
    			first_name = "Deepu",
    			last_name = "Madhusoodanan"
    		};
    		
    		var email_addresses = new List<EmailAddress>
    		{
    			new EmailAddress{email_address = "deepumi1@gmail.com"}
    		};
    
    		cont.email_addresses = email_addresses;
    		cont.lists = new List<List>
    		{
    			new List {id = "<Replace with your List Id>"}
    		};
    
    		var json = Newtonsoft.Json.JsonConvert.SerializeObject(cont);
    		string MessageType = "application/json";
    		using (var request = new HttpRequestMessage(System.Net.Http.HttpMethod.Post, "https://api.constantcontact.com/v2/contacts?api_key=<Replace with your API key>"))
    		{
    			request.Headers.Add("Accept", MessageType);
    
    			request.Content = new StringContent(json);
    			request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse(MessageType);
    
    			using (var response = await client.SendAsync(request).ConfigureAwait(false))
    			{
    				string responseXml = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
    				var code = response.StatusCode;
    			}
    			request.Content.Dispose();
    		}
    	}
    }
    catch (Exception exp)
    { 
      //log exception here
    }
    /*Model class*/
    public class Address
    {
    	public string address_type { get; set; }
    	public string city { get; set; }
    	public string country_code { get; set; }
    	public string line1 { get; set; }
    	public string line2 { get; set; }
    	public string line3 { get; set; }
    	public string postal_code { get; set; }
    	public string state_code { get; set; }
    	public string sub_postal_code { get; set; }
    }
    
    public class List
    {
    	public string id { get; set; }
    }
    
    public class EmailAddress
    {
    	public string email_address { get; set; }
    }
    
    public class ContactObject
    {
    	public List<Address> addresses { get; set; }
    	public List<List> lists { get; set; }
    	public string cell_phone { get; set; }
    	public string company_name { get; set; }
    	public bool confirmed { get; set; }
    	public List<EmailAddress> email_addresses { get; set; }
    	public string fax { get; set; }
    	public string first_name { get; set; }
    	public string home_phone { get; set; }
    	public string job_title { get; set; }
    	public string last_name { get; set; }
    	public string middle_name { get; set; }
    	public string prefix_name { get; set; }
    	public string work_phone { get; set; }
    }
