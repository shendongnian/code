     [HttpGet]
     [Route("FindAll")]
     public IEnumerable<Hotel> FindAll(string[] IncludeProperties, string Predicate)
     {
        Dictionary<string,string[]> predicateAsDictionary = JsonConvert.DeserializeObject<Dictionary<string, string[]>>(predicateString)
        return DataStore.FindAll<Hotel>(IncludeProperties, predicateAsDictionary);
     }
