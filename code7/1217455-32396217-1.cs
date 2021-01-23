		[ExpandableProperty("Documents", false)]
        public IQueryable<ClientActivity> GetAllClientActivities()
        {
            return Query(); 
        }
