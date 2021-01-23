    using (ClientContext context = new ClientContext("http://site_url/"))
    {
    	context.Credentials = new NetworkCredential("user_login", "user_password", "DOMAIN");
    	List list = context.Web.Lists.GetByTitle("My list");
    	context.Load(list);
    	context.ExecuteQuery();
    	Console.WriteLine(list.Id);
    	Console.ReadKey();
    }
