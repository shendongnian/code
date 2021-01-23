     class MobOwner {
       public string Name { get; set; } 
       public List<string> Mobiles { get; } = new List<string>();
    
       public MobOwner(string name, IEnumerable<string> mobiles): base() {
         if (null == name)
           throw new ArgumentNullException("name");
         if (null == mobiles)
           throw new ArgumentNullException("mobiles");
         Name = name;
    
         Mobiles.AddRange(mobiles); 
       }
     }
