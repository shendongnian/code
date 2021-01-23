    struct ValuePair
    {
       public string Name {get; set;}
       public string Id {get; set;}
    
       public ValuePair(string name, string id)
       {
          this.Name = name;
          this.Id = id;
       }
      
       public string ToString()
       {
           return "Name : " + Name + ", Id : " + Id;
       }
    }
