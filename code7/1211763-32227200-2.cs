    public class MyReqAttribute : RequiredAttribute
    {
        private string _errorID;
        public MyReqAttribute(string errorID)
        {
            _errorID=errorID;           
        }
        public override string FormatErrorMessage(string name)
        {
            string language = !String.IsNullOrEmpty(HttpContext.Current.Request.QueryString["l"])? HttpContext.Current.Request.QueryString["l"]: "en-en";
            var translation = RegistrationScriptHelper.Translation.GetRegistrationScript(HttpContext.Current.Request).Find(x => x.Language == language);
            this.ErrorMessage = translation.Item.Find(x => x.Id == errorID 
                && x.Type == "Required").Text;
            return base.FormatErrorMessage(name);
        }
    }
