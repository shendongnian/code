      public class Logic{
            private DAL dal = new DAL();
            public dynamic dataGet(int id, string name){
             var a = (from data where dal.getAllRecords()
                       where data.ID == id && data.name == name
                       select new{
                            dataid = data.ID
                            daname = data.name   
                       }).ToList();
              return a;
           }
     }
