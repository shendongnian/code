    string input = "!doar 12345, rayantt";
    string searchString = "!doar";
    string strParam=string.Empty ;
    int intParam=0;
    if (input.Contains(searchString)) // check for the existence of the search string in given string
       {
          input = input.Replace(searchString, ""); // remove the searchstring from the input
          string[] contents = input.Split(',');
          int.TryParse(contents[0], out intParam); // collect the integer param
          strParam=contents[1]; // collect the string param
       }
    // here you get 12345 in intParam and "rayantt" in strParam
