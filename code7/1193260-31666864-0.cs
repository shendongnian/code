        public static List<string> GetValuesFromDB(string column)
        {
            GradInfoEntities db = new GradInfoEntities();
            //if i pass the column name in it doesn't work
            //i suspect that if i pass as param, it gets quoted coz i'm passing in the value, not the column
            var temp = db.Grads.Where(string.Format("{0} != null", column)).Select(column);
            
            List<string> result = temp.Cast<string>().ToList();
            return result;
        }
