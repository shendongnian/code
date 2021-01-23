    string customerText = 
    "Dear Customer +CustName+ Thank you for visiting Here, Your Bill Amount is : +BillTotal+";
      string[] splitResult = text.Split('+');
      StringBuilder finalText = New StringBuilder();
      for (int i = 0; i < splitResult.Count; i++)
      {
          string originText = splitresult[i];
          string resultText = originText;
          if(i % 2 != 0)
              resultText = YourMethodToGetValueByKey(origintext);
          finalText.Append(resulttext);
      }
      Console.WriteLine(finalText.ToString()); //Print result
