    public class Product
    {
      public Product()
      {
        this.Price = new Price();
      }
      public int Id { get; set; }
      public string Description { get; set; }
      [NotMapped]
      public Price Price { get; set; }
      [Column("Price")]
      public string RawPrice 
      {
        get
        {
          return this.Price.<yourfield>;  
        }
        set
        {
          this.Price.SetRawValue(value);
        }
      }
      [Column("Currency")]
      public string RawCurrency
      {
        get
        {
          return this.Price.<yourfield>;  
        }
        set
        {
          this.Price.SetRawCurrency(value);
        }
      }
    }
    public class Price
    {
      public decimal Amount { get; set; }
      public string Currency { get; set;
      public void SetRawPrice(string value)
      {
        //parse raw value into amount
      }
      public void SetRawCurrency(string value)
      {
        //parse raw value into currency
      }
    }
