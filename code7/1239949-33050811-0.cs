    string input="(h1+h2+h3)";
    String newString = input.Replace("("," ( ").Replace(")"," ) 
    "
    ).Replace("+"," + "); // Reformat string by separating symbols
    String[] splitStr = newString.Split(new char[]{' '});
    foreach(string x in splitStr)
    {
      Console.WriteLine(x);    
    }
