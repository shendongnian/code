     interface IData1
     {
         int Id { get;set; }
         int BranchId { get;set; }
     }
     
     interface IData2 
     {
         int LocationId { get;set; }
         int DepID { get;set; }
     }
     interface IData3
     {
          int Age { get;set; }
          string Name { get;set; }
     }
     public class A : IData1, IData2, IData3
     {
          public int Id { get;set; }
          public int BranchId { get;set; }
          public int LocationId { get;set; }
          public int DepID { get;set; }
          public int Age { get;set; }
          public string Name { get;set; }
     }
     public class B : IData2, IData3
     {
         public int LocationId { get;set; }
         public int DepID { get;set; }
         public int Age { get;set; }
         public string Name { get;set; }
     }
     public class C : IData3
     {
         public int Age { get;set; }
         public string Name { get;set; }
      }
     void WriteData1(IData1 data){}
     void WriteData2(IData2 data){}
     void WriteData3(IData3 data){}
     void WriteProperties(A a, B b, C c)
     {
           WriteData1(a);
           WriteData2(a);
           WriteData2(b);
           WriteData3(a);
           WriteData3(b);
           WriteData3(c); 
      }
