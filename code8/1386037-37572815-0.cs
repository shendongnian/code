        public List<Visitor> AllVisitors()
        {
            
            using (TurnstileDbEntities te = new TurnstileDbEntities())
            {
                te.Configuration.ProxyCreationEnabled = false;
                return te.Visitors.ToList<Visitor>();
            }
        }
