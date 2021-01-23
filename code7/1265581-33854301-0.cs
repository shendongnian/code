    string subString = Console.ReadLine().Substring(0,7);
    //Check if the whole string is a parsable number
    if(int.TryParse(subString) == false) 
    {
          Console.WriteLine("Not a valid number..."); 
          return;
    } 
    //convert it an int[]
    int[] values = subString.ToCharArray().Select( value => int.Parse(value.ToString())).ToArray();
 
