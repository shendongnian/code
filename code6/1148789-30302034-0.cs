    public Contacts ReadDaysLeft(int daysid, out DateTime dt)            
    {               
        using (var dbConn = new SQLiteConnection(App.DB_Path))               
        {                  
          var data = dbConn.Query<DaysLeft>("select  * from DaysLeft where Id = " + daysid).FirstOrDefault();
    
          dt =  Convert.ToDateTime(data.Date);      
          return data;                
        }      
    }
