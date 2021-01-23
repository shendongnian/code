        [HttpGet]
        [GetCountFilter]
        public async Task<CountList<T>> GetOverview()
        {
            //special case, we only need the count !
            if (ServerContext.QueryFilter.CountOnly) //custom object that parses the queryParameters
            {
                //todo, but out of scope here,, make a real Count method in the manager that actually executes a count query instead of fetching the whole list
                var count = (await _entityManager.GetOverview()).Count; 
                var result = new CountList<T>(count);
                return result;
            }
            //return the full list
            return new CountList<T>( await _entityManager.GetOverview());
        }
		
