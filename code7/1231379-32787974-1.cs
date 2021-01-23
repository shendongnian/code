    public class MyObj{
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public static MyObj GetObject(int prmId){
         var obj = DAL.get(prmId).FirstOrDefault();
         return obj != null ? obj : new MyObj();
        }
    }
    static class DAL {
         public static List<MyObj> get(int? prmId){ 
             // database stuff to call a Stored Procedure and return 0 or more MyObjs
         }
    }
