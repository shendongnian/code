        public List<State> GetStates()
        {
            using (var db = new DbContext(ConfigurationManager.ConnectionStrings["DefaultConnection"]))
            {
                return db.States.ToList();
            }
        }
