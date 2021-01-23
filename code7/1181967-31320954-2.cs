    public void Main(string[] args)
    {
       while(!doesUserWantToLeave) {
          Console.WriteLine("Please specify the type of conversion you would like to accomplish:" 
          + "\n(Bronze, Silver, 14k Gold, 18k Gold, 22k Gold, Platinum, or Exit):");
          string conversionType = Console.ReadLine();
          Console.WriteLine("What is the weight of the wax model?");
          double waxWeight = double.Parse(Console.ReadLine());
          double weight = ConvertMethod(conversionType, waxWeight);
          Console.WriteLine(string.Format("You need {0} grams of {1}.", weight, conversionType));
       }
    }
