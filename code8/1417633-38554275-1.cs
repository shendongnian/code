    public ActionResult PaginationOfBooks(string _title, string _author, string _description, string _publisher)
            {
    
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:57752");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
                HttpResponseMessage response = client.GetAsync("api/Book/GetBooks/" + _title + "/" + _author + "/" + _description + "/" + _publisher).Result;
