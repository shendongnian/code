        const string uri = "https://www.webservice.com/api/getdata";
        private List<MyListItem> myList;
        
        public static async Task<MyRepository> GetMyRepository()
        {
            MyRepository myRepository = new MyRepository();
            await myRepository.LoadDataAsync(uri);
            
            return myRepository; 
        }
        public MyRepository()
        {
        }
        public async Task LoadDataAsync(string uri)
        {
            if (allRecords != null) **// Breakpoint here never hit.**
            {
                string responseJsonString = null;
    
                using (var httpClient = new HttpClient())
                {
                    try
                    {
                        Task<HttpResponseMessage> getResponse = httpClient.GetAsync(uri);
                        HttpResponseMessage response = await getResponse;
                        responseJsonString = await response.Content.ReadAsStringAsync();
                        myList = JsonConvert.DeserializeObject<List<MyListItem>>(responseJsonString);
                    }
                    catch (Exception ex)
                    {
    
                    }
                }
            }
        }
