    public List<Student> Students
    {
       get
       {
           if(Session["Students"] == null)
           {
               Session["Students"] = new List<Student>
               {
                   new Student {Id = 1, Name = "Name1"},
                   new Student{Id = 2 , Name = "Name2"},
                   new Student{Id = 3 , Name = "Name3"},
               };
           }
           return Session["Students"] as List<Student>;
       }
       set
       {
           Session["Students"] = value;
       }
    }
