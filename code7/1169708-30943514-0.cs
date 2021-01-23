    System.DateTime dateTimeOut;
    var culture = CultureInfo.CreateSpecificCulture("en-GB");
    var styles = DateTimeStyles.None;
    if (DateTime.TryParse("18/06/2015", culture, styles, out dateTimeOut))
    {
      Console.WriteLine("Good Job!");
    }
