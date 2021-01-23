      // class "Customer"...
      public class Customer {
        public int Id { get; set; }
        public string Name { get; set; }
    
        // Constructor
        public Customer(int ID, string Name)
        {
           this.Id = ID;
           this.Name = Name; 
        }
    
        // Constructor "Customer" has the same name that the class it creates
        public Customer()
        {
            this.Id = -1;
            this.Name = string.Empty;
        }
    
        public void PrintId()
        {
            Console.WriteLine(this.Id);
        }
    
        public void PrintName()
        {
            Console.WriteLine(this.Name);
        }
      }
