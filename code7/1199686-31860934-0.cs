    public class Student
        {
          
            [Key]
            public int StudentKey { get; set; }
         
            public string StudentName { get; set; }
        }
    and in Entityframework you donot write any thing just use Below class that create automatic Primarykey 
   
     Class student
        {
        public int id {get;set}
        public string Name {get;set}
        }
    more detail why should this happen read below article
    [Entity Framework][1]
