       class Weight
       {
           public int Id { get; set; }
           public override bool Equals(object obj)
           {
               return Id == ((Weight)obj).Id;
           }
       }
