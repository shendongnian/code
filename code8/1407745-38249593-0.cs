    //A list to hold the result
    List<int> values = new List<int>();
    //loop through each character 1 by 1
    foreach(var c in myString)
    {
         //will hold the value
         int num = 0;
         //Try to parse the character into an integer
         var isNumber = int.TryParse(c.ToString(), out num);
         //if the parsing succeeded add it to the list
         if(isNumber)
         {
             values.Add(num);
         }
    }
