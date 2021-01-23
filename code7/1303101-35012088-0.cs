        public static List<SelectListItem> getTable<T>(this MyDbContext db)
        {
                List<SelectListItem> ImproItems = new List<SelectListItem>();
                if (typeof(T) == null) return ImproItems;
                List<T> Ts = ((IEnumerable<T>) db.GetType().GetProperty(typeof(T).Name).GetValue(db, null)).ToList(); //.Select(ii => new SelectListItem( (T)ii)); //does not work directly
                foreach(dynamic t in Ts)
                {
                    ImproItems.Add(new SelectListItem(t));
                }
