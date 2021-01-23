     //In Customer class, changed following line:
     public virtual IEnumberable<PhoneNumber> { get; set; }
     //To:
     public virtual ICollection<PhoneNumber> { get; set; }
     //Then in using block initialized entities as follows:
     using(var context = new SampleContext())
     {
          var customer = new Customer { ID = 1, Name = "John", PhoneNumbers = new List<PhoneNumber>() };
          customer.PhoneNumbers.Add(new PhoneNumber { ID = 1, Number = "1.111.1111111" });
          context.Customers.Add(customer);
          context.SaveChanges();
     }
