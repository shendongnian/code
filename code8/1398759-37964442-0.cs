        public static void deleteRecord(TestAsfa TA,int id)
        { 
             using(var d = new TestEntities())
             {
                TA= d.TestAsfa.Where(item => item.ItemId == id).FirstOrDefault(); 
                if (itemTA!= null) {
                   d.TestAsfa.Remove(TA);
                }
             }             
         
        }
