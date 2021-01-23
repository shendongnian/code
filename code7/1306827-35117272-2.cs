    string positiveString = "91389681247993671255432112000000";
    string negativeString = "-90315837410896312071002088037140000";
    BigInteger b = BigInteger.Parse(positiveString);
    BigInteger c = BigInteger.Parse(positiveString);
    BigInteger d = b * c;
    System.Console.WriteLine(d);
    System.Console.ReadLine();
    // result 835207383860988607360648144841987935757186784078054400000000000
