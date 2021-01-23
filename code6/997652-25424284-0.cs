     public ActionResult getID()
            {
                string qry = "SELECT COUNT(JobID) FROM tblDriverJob";
                IEnumerable<int> data = db.Database.SqlQuery<int>(qry);
                int newFuelID = data.Single() + 1;
                string i = Convert.ToString(newFuelID);
    
    
                return new ContentResult { Content = i };
    
            }
