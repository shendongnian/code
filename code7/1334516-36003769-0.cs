     [HttpPost]
     public ActionResult Search(string searchtext, int? year)
        {            
            try
            {
                if (year != null) //you will need to handle the case where year = null
                {
                    string selyear = year.ToString();
