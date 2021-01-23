    public class MyNumericUpDown : NumericUpDown {
    
      protected override double ParseValue(string text)
      {
         // Change text to whatever you want
         string newText = FixText(text);
    
         // Call base implementation.
         base.ParseValue(newText);
      }
    
      private static string FixText(string inputText) {
        // DO YOUR STUFF HERE.
      } 
    }
