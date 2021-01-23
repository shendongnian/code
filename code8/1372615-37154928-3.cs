      public string LoadItemNew(int ItemID)
        {
                List<string> testList = new List<string>();            
        
            var acf = new AcFunctions();
        
        
            var newstorevalue = SqlHelper.ExecuteReader(acf.AcConn(), "sp_lightItem", new SqlParameter ("@itemID",ItemID));
        
         if(newstorevalue.HasRows)
        {
         
         
        
         
        
               while(newstorevalue.Read())
               {
                   testList.Add(newstorevalue["itemID"].ToString());
                   testList.Add(newstorevalue["itemName"].ToString());
                   testList.Add(newstorevalue["itemLocation"].ToString());
                   testList.Add(newstorevalue["itemChBy"].ToString());
              }
        
        }
    
     }
