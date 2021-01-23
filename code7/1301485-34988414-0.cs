      public static List<List<string>> GetCountryData()
            {
                List<List<string>> DataRows = null;
                using (((WindowsIdentity)HttpContext.Current.User.Identity).Impersonate())
                {
                    using (var dbContext = new UNITY_DB_PRODEntities())
                    {
    
                        DataRows = dbContext.final_full_data.Where(x => x.computername.Contains("m570")).Select(x => new List<string> { x.computername, x.DCAI_CENTRE, x.AD_CN }).AsEnumerable().ToList();
                    }
                }
                return DataRows;
            }
