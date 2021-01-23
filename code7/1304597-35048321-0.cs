    using System.Text.RegularExpressions;
    .......
    
    private void SubmitButton_Click(object sender, RoutedEventArgs e) {
    
      // Step 1- split the string after each blank space
      string[] numbersInTextBox = Regex.Split("10.4 22.5 11.6", @" ");
    
      //Step 2 - convert to double and add to the list
      foreach (string strNumber in numbersInTextBox)
      {
               double dNumber = Convert.ToDouble(strNumber);
               dNumbers.Add(dNumber);
      }
      
    }
