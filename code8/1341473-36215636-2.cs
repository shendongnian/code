    string customerText = 
    "Dear Customer +CustName+ Thank you for visiting Here, Your Bill Amount is : +BillTotal+";
      string[] splitResult = text.Split('+');
      StringBuilder finalText = New StringBuilder();
      for (int i = 0; i < splitResult.Count; i++)
      {
          string originText = splitresult[i];
          if(i % 2 == 0)
              finalText.Append(originText)
          else // odd index - keyword to replace
              finalText.Append(YourMethodToGetValueFromDatabaseByKey(origintext));
      }
      Console.WriteLine(finalText.ToString()); //Print result
