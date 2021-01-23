      string input = "tony's auto shop 123 main st.";
      //Gets rid of spaces and replaces with '-'
      string result = System.Text.RegularExpressions.Regex.Replace(input, @"\s+-?\s*", "-");
      //Replaces all special characters with nothing, with the exception of '-'
      result = System.Text.RegularExpressions.Regex.Replace(result, "[^a-zA-Z0-9 -]", "");
      Console.WriteLine(result);
      Console.ReadLine();
