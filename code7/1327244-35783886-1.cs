     static public async Task<Tuple<Dictionary<String,String>,CookieContainer>> login(string server, string id, string pw)
        {
         CookieContainer cookies = new CookieContainer();
          Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
    // create result tuple
         var result = Touple.create(dictionary2,cookies);
         return result;
        }
