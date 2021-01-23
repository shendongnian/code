    public Customer(int ID, string FirstName){
          if (ID < 0)
              throw new ArgumentException("ID cannot be less than 0");
          if (string.IsNullOrEmpty(FirstName))
              throw new ArgumentException("First Name cannot be empty");
    
          this.ID = ID;
          this.FirstName = FirstName;
       }
