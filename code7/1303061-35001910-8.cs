[HttpGet]
public async Task&lt;string&gt; Get()
{
    var client = new HttpClient();
    var customer = new Customer() { Name = "Schmo", Address = "1999 Purple Rain St" };
    var customerJson = JsonConvert.SerializeObject(customer);
    var response = await client.PostAsync(
                    "http://localhost:4815/api/Customer",
                    new StringContent(customerJson, Encoding.UTF8, "application/json"));
    //just some template output to test which I'm getting back.
    string resultJson = "{ 'Name':'adam'}";
    if (response.StatusCode == HttpStatusCode.OK)
    {
        resultJson = await response.Content.ReadAsStringAsync();
        var updatedCustomer = JsonConvert.DeserializeObject(resultJson);
    }
    return resultJson;
}
public class Customer
{
    public string Name { get; set; }
    public string Address { get; set; }
}
