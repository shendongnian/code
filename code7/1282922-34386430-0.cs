    public class MyMethodQuery
     {
        public string Id { get; set; } = "Inialized";
       public MyMethodQuery ()
       {
           if (string.IsNullOrEmpty(this.Id))
               throw new System.ArgumentException("Parameter cannot be null");
       }
   }
