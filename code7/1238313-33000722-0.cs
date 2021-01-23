    async void Main()
    {
    	var textBox2String = "2"
    
    	if (!string.IsNullOrEmpty(textBox2String))
        {
    		const string table = "Entry";
    		
    		var client = new HttpClient();
    		var url = $"https://myurl.com/rest/services/{table}";
    		var xml = $"<Entry><ID1>{textBox2String}</ID1></Entry>";
    		
    		client.DefaultRequestHeaders.TryAddWithoutValidation("CustomUserName", "username");
    		client.DefaultRequestHeaders.TryAddWithoutValidation("CustomPassword", "password");
    		
    		var response = await client.PostAsync(url, new StringContent(xml, Encoding.UTF8, "text/xml"));
    		var content = await response.Content.ReadAsStringAsync();
    
    		if (response.IsSuccessStatusCode)
    		{
    			var document = XDocument.Parse(content);
    			var entry = document.Root.Element(table);
    			var firstName = entry.Element("FirstName").Value;
    			var lastName = entry.Element("LastName").Value;
    
    			$"{firstName} {lastName}".Dump();
    		}
    		else
    		{
    			Console.WriteLine($"An error occurred processing this request: {content}");
    		}
        }
        else
        {
            textBox2String = "Please enter an ID";
        }
    }
