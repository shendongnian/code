    System.DateTime dateTimeOut;
    if(DateTime.TryParse("18/06/2015", new CultureInfo("it-IT"), DateTimeStyles.None, out dateTimeOut))
    {
      Console.WriteLine("Good Job!");
    }
