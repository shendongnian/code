    static void searchWords(ArrayList arlWords)
    {
      string strInput;
      bool check= false;
      Console.Write("Search a Word: ");
      strInput = Console.ReadLine();
      for (int i = 0; i < arlWords.Items.Count; i++)
      {
         if (arlWords.Items[i] == strInput )
            check = true;
      }
      if(check) Console.WriteLine("found");
      else Console.WriteLine("not found");
    }
