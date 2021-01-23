    public class MyMaxLengthAttribute : MaxLengthAttribute
    {
         private static String CustomErrorMessage = "{0} length should not be more than {1}";
         public MyMaxLengthAttribute(int length) : base(length)
         {
             ErrorMessage = "What should I input here"
         }
         public override string FormatErrorMessage(string name)
         {
            if (!String.IsNullOrEmpty(ErrorMessage))
            {
                ErrorMessage = MyErrorMessage;
            }
            return String.Format(CultureInfo.CurrentUICulture, CustomErrorMessage , name);
         }
    }
