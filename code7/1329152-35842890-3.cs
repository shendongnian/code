    string num;
    num = "1,000";      Console.WriteLine("{0}", DecimalParse(num));     //1000
    num = ",01";        Console.WriteLine("{0}", DecimalParse(num));     //0.01
    num = ".02";        Console.WriteLine("{0}", DecimalParse(num));     //0.02
    num = "12,1";       Console.WriteLine("{0}", DecimalParse(num));     //12.1
    num = "12.1";       Console.WriteLine("{0}", DecimalParse(num));     //12.1
    num = "1.000,12";   Console.WriteLine("{0}", DecimalParse(num));     //1000.12
    num = "1.000.000,12"; Console.WriteLine("{0}", DecimalParse(num));   //1000000.12
    num = "1,000.12";   Console.WriteLine("{0}", DecimalParse(num));     //1000.12
    num = "1,000,000.12"; Console.WriteLine("{0}", DecimalParse(num));   //1000000.12
    num = "1000";       Console.WriteLine("{0}", DecimalParse(num));     //0
    num = "110.";       Console.WriteLine("{0}", DecimalParse(num));     //0
    num = "110,";       Console.WriteLine("{0}", DecimalParse(num));     //0
    num = "1.2.3";      Console.WriteLine("{0}", DecimalParse(num));     //0
    num = "1,2,3";      Console.WriteLine("{0}", DecimalParse(num));     //0
