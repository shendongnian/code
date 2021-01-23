    using System;
    using System.Globalization;
    public class PrintCurrencyValue  {
       public static void Main()  {
          double x = 12.5;
          RegionInfo myRI1 = new RegionInfo( "ar-EG" );
          Console.WriteLine( "CurrencySymbol:    {0} {1:N}", myRI1.CurrencySymbol, x);
          Console.WriteLine( "ISOCurrencySymbol: {0} {1:N}", myRI1.ISOCurrencySymbol, x);
       }
    }
