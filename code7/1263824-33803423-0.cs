    class Program
    {
      static void Main()
      {
        Customer[] office1 =
                {
                   new Customer {Id = 1,  OrderNo = 1, Name = "Joe", Surname = "Bloggs", City = "London"},
                    new Customer {Id = 2,  OrderNo = 2, Name = "Mark", Surname = "Smith", City = "Manchester"},
                    new Customer {Id = 3,  OrderNo = 3, Name = "Emily", Surname = "Blunt",  City = "Liverpool"},
                    new Customer {Id = 5,  OrderNo = 6, Name = "XX", Surname = "YY",  City = "ZZ"},
                };
    
        Customer[] office2 =
                {
                    new Customer {Id = 1,  OrderNo = 1, Name = "Joe", Surname = "Bloggs",  City = "London"},
                    new Customer {Id = 2,  OrderNo = 2, Name = "Mark", Surname = "SmithError", City = "Manchester"},
                    new Customer {Id = 3,  OrderNo = 4, Name = "EmilyError", Surname = "Blunt", City = "LiverpoolError"},
                    new Customer {Id = 4,  OrderNo = 5, Name = "X", Surname = "Y", City = "Z"},
                };
    
        var customerOffice1 = office1.Except(office2);
        var customerOffice2 = office2.Except(office1);
        var diffIds = customerOffice1.Select(o => o.Id)
                  .Intersect( 
                      customerOffice2.Select(o => o.Id) 
                  );
        var difList = diffIds
          .SelectMany(i => customerOffice1.SingleOrDefault(o => o.Id == i)
          .GetDifference(customerOffice2.SingleOrDefault(o => o.Id == i)));
         // LinqPad
         // difList.Dump();
      }
    }
    
    public class Difference
    {
      public int Id { get; set; }
      public string PropertyName { get; set; }
      public string OldValue { get; set; }
      public string NewValue { get; set; }
    }
    
    public class Customer : IEquatable<Customer>
    {
      public int Id { get; set; }
      public string Name { get; set; }
      public string Surname { get; set; }
      public string City { get; set; }
      public int OrderNo { get; set; }
    
      public List<Difference> GetDifference(Customer other)
      {
        return this.GetType().GetProperties()
          .Where(t => t.Name != "Id" && 
            t.GetValue(this).ToString() != t.GetValue(other).ToString() )
          .Select(t => new Difference { 
            Id = this.Id,
            PropertyName = t.Name,
            OldValue = t.GetValue(this).ToString(), 
            NewValue = t.GetValue(other).ToString()
            }).ToList();
      }
    
      public bool Equals(Customer other)
      {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return string.Equals(Name, other.Name)
            && string.Equals(Surname, other.Surname)
            && string.Equals(City, other.City);
      }
    
      public override bool Equals(object obj)
      {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Customer)obj);
      }
    
      public override int GetHashCode()
      {
        unchecked
        {
          var hashCode = (Name != null ? Name.GetHashCode() : 0);
          hashCode = (hashCode * 397) ^ (Surname != null ? Surname.GetHashCode() : 0);
          hashCode = (hashCode * 397) ^ (City != null ? City.GetHashCode() : 0);
          return hashCode;
        }
      }
    
      public static bool operator ==(Customer left, Customer right)
      {
        return Equals(left, right);
      }
    
      public static bool operator !=(Customer left, Customer right)
      {
        return !Equals(left, right);
      }
    }
