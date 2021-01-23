    public class CustomRegularExpressionAttribute : RegularExpressionAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            string currentLang = Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName;
            CultureInfo ci = new CultureInfo(currentLang);
            return HttpContext.GetGlobalResourceObject(ErrorMessageResourceType.Name.ToString(), ErrorMessageResourceName, ci).ToString();
        }
        public CustomRegularExpressionAttribute(string pattern)
            : base(pattern)
        {
        }
    }
