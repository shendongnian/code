    //Add a field to Money: public MoneyDescription Description;
    enum MoneyDescription
    {
      AdultFare,
      AdultFee,
      ....
      TotalFee
    } 
    List<Money> V = new List<Money>();
    foreach (MoneyDescription md in Enum.GetValues(typeof(MoneyDescription)))
    {
      V.Add(new Money() {Description = md});
    }
