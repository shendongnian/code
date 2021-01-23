     public static string GetRefNo()
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                string tickPrefix = db.Users.Where(u => u.Username.Equals((String)HttpContext.Current.Session["Username"])).Select(u => u.TicketPrefix).SingleOrDefault();
                int xyear = db.Users.Where(u => u.Username.Equals((String)HttpContext.Current.Session["Username"])).Select(u => u.Last_Login_Datetime.Value.Year).SingleOrDefault();
                int xmonth = db.Users.Where(u => u.Username.Equals((String)HttpContext.Current.Session["Username"])).Select(u => u.Last_Login_Datetime.Value.Month).SingleOrDefault();
                int xday = db.Users.Where(u => u.Username.Equals((String)HttpContext.Current.Session["Username"])).Select(u => u.Last_Login_Datetime.Value.Day).SingleOrDefault();
                int xcounter = int.Parse(db.Users.Where(u => u.Username.Equals((String)HttpContext.Current.Session["Username"])).Select(u => u.Counter).SingleOrDefault().ToString());
                xcounter++;
                var query = db.Users.Where(u => u.Username.Equals((String)HttpContext.Current.Session["Username"])).Select(u => u).ToList();
                foreach (var item in query)
                {
                    if (item != null)
                    {
                        db.ExecuteCommand("UPDATE [CRM].[dbo].[tbl_User_master] SET [Counter] = {0} WHERE Ref_no = {1}", xcounter, item.Ref_no);
                    }
                }
                string c = (xcounter < 10) ? xcounter.ToString().PadLeft(2, '0') : xcounter.ToString();
                string m = (xmonth < 10) ? xmonth.ToString().PadLeft(2, '0') : xmonth.ToString();
                string d = (xday < 10) ? xday.ToString().PadLeft(2, '0') : xday.ToString();
                return tickPrefix + xyear.ToString().Substring(3, 1) + m + d + c;
            }
        }
