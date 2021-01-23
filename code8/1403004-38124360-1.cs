       public static List<ItemClass> ItemsFromCategory(string ID)
       {
           LoginData lData = (LoginData)HttpContext.Current.Session["LData"];
           
           System.Web.Script.Serialization.JavaScriptSerializer ser = new System.Web.Script.Serialization.JavaScriptSerializer();
           List<ItemClass> myList = new List<ItemClass>();
           
          if (lData != null)
           {
               ClsDataAccess cData = new ClsDataAccess();
               DataTable dt = cData.GetTable("Select itmid,ITMNAME from FBITEMDETAILS where itmtype='I' and itmisprimary='N' and itmoutletid=" + lData.fbOutLetid + " and itmgrpid=" + ID);
              // DataTable dt = cData.GetTable("Select itmid,ITMNAME from FBITEMDETAILS where itmtype='I' and itmisprimary='N' and itmgrpid=" + ID);
               foreach (DataRow row in dt.Rows)
               {
                   myList.Add(new ItemClass
                   {
                       ID = row["itmid"].ToString(),
                       itemName=row["ITMNAME"].ToString(),
                       
                   });
               
               }
              // result = ser.Serialize(myList);
           //    return result;
               return myList;
           }
          // return string.Empty;
           return myList;
           
       
       }
