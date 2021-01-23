    private void SubmitButton_Click(object sender, RoutedEventArgs e) {
      // Try to parse the numbers
      double  numberOne, numberTwo;
      bool isTextOneNumber = Double.TryParse(text1.Text, out numberOne);
      bool isTextTwoNumber = Double.TryParse(text2.Text, out numberTwo);
      if(isTextOneNumber && isTextTwoNumber )
      {
         //calculate what you want with numberOne, numberTwo
      }
      else
      {
        //provide some error(validation) message
      }
    }
