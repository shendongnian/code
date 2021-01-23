      public partial class SpecificInputForm : GeneralInputForm
      {
           // Blank textboxes are not valid, and are restricted to 31 characters
           protected override bool IsValid(string text)
           {
               if (string.IsNullOrWhitespace(text))
                   return false;
               return (text.Length < 32);
           }
      }
