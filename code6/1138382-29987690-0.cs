    public class Address
    {
      public string Street { get; set; }
      public string StreetNumber { get; set; }
      public string FlatNumber { get; set; }
      public string PostalCode { get; set; }
      public string City { get; set; }
      public override string ToString()
      {
        string flatNumberStr = !string.IsNullOrEmpty(FlatNumber) ? " / " + FlatNumber : "";
        return string.Format("{0} {1}{2} {3:00-000} {4}", Street, StreetNumber, flatNumberStr, int.Parse(PostalCode), City);
      }
    }
    private static void Main(string[] args)
    {
      Address addr1 = new Address()
      {
        Street = "Some Street",
        StreetNumber = "123",
        FlatNumber = "F3",
        PostalCode = "54897",
        City = "Big City"
      };
      Address addr2 = new Address()
      {
        Street = "Other Street",
        StreetNumber = "12B",
        PostalCode = "06816",
        City = "Smaller City"
      };
      Console.WriteLine(addr1.ToString());
      Console.WriteLine(addr2.ToString());
    }
