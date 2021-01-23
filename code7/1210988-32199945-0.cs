      using System.Configuration; 
      using System.Globalization;   
            /// <summary>
    
            /// populate country name
    
            /// </summary>
    
            /// <param name="dropDown"></param>
    
            public static void GetCountryNames(DropDownList dropDown)
    
            {
    
                Hashtable h = new Hashtable();
    
    
    
                Dictionary<string, string> objDic = new Dictionary<string, string>();
    
                foreach (CultureInfo ObjCultureInfo in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
    
                {
    
                    RegionInfo objRegionInfo = new RegionInfo(ObjCultureInfo.Name);
    
                    if (!objDic.ContainsKey(objRegionInfo.EnglishName))
    
                    {
    
                        objDic.Add(objRegionInfo.EnglishName, objRegionInfo.TwoLetterISORegionName.ToLower());
    
                    }
    
                }
    
    
    
                SortedList<string, string> sortedList = new SortedList<string, string>(objDic);
     
    
                foreach (KeyValuePair<string, string> val in sortedList)
    
                {
    
                    dropDown.Items.Add(new ListItem(val.Key, val.Key));
    
                }
    
    
    
                dropDown.Items.Insert(0, new ListItem("Select", "Select"));
    
                dropDown.Items.Insert(1, new ListItem("Other Country", "Other"));
    
            }
    
        }
    
    
