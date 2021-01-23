    public class CheckSpellingAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string stringValue = value as string;
            if (string.IsNullOrEmpty(stringValue) != false)
            {
                //your spelling validation logic here
                return isSpellingCorrect(stringValue );
            }
            return true;
       }
    }
