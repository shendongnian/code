    public class RequiredFieldValidator : CustomValidator
    {
        public string CssControlErrorClass { get; set; }
        public RequiredFieldValidator()
        {
            ClientValidationFunction = "validators.required";
            ValidateEmptyText = true;
        }
        public string InitialValue
        {
            get
            {
                object o = ViewState["InitialValue"];
                return ((o == null) ? String.Empty : (string)o);
            }
            set
            {
                ViewState["InitialValue"] = value;
            }
        }
        protected override void Render(HtmlTextWriter writer)
        {
            //Have to add attributes BEFORE the beginning tag is written to the stream
            writer.AddAttribute("data-errorClass", CssControlErrorClass);
            writer.AddAttribute("data-for", GetControlRenderID(ControlToValidate));
            base.Render(writer);
        }
        protected override bool EvaluateIsValid()
        {
            //Default implementation of the RequiredFieldValidation validator
            string controlValue = GetControlValidationValue(ControlToValidate);
            if (controlValue == null)
            {
                return true;
            }
            var result = (!controlValue.Trim().Equals(InitialValue.Trim()));
            //Check to see if validation failed, if it did, add the class to the control to validate
            if (!result)
            {
                var control = (WebControl) NamingContainer.FindControl(ControlToValidate);
                //Didn't look into it too much, but the validators fire twice for some reason
                if(!control.CssClass.Contains(CssControlErrorClass)) control.CssClass += " " + CssControlErrorClass;
            }
            
            return result;
        }
    }
    public class RegularExpressionValidator : CustomValidator
    {
        public string CssControlErrorClass { get; set; }
        public string ValidationExpression
        {
            get
            {
                object o = ViewState["ValidationExpression"];
                return ((o == null) ? String.Empty : (string)o);
            }
            set
            {
                try
                {
                    Regex.IsMatch(String.Empty, value);
                }
                catch (Exception e)
                {
                    throw new HttpException(string.Format("{0} - {1}", "Validator_bad_regex", value), e);
                }
                ViewState["ValidationExpression"] = value;
            }
        }
        public RegularExpressionValidator()
        {
            ClientValidationFunction = "validators.regex";
        }
        protected override void Render(HtmlTextWriter writer)
        {
            //Have to add attributes BEFORE the beginning tag is written to the stream
            writer.AddAttribute("data-errorClass", CssControlErrorClass);
            writer.AddAttribute("data-regex", ValidationExpression);
            writer.AddAttribute("data-for", GetControlRenderID(ControlToValidate));
            base.Render(writer);
        }
        protected override bool EvaluateIsValid()
        {
            //Default implementation of the RegularExpressionFieldvalidator
            string controlValue = GetControlValidationValue(ControlToValidate);
            if (controlValue == null || controlValue.Trim().Length == 0)
            {
                return true;
            }
            try
            {
                Match m = Regex.Match(controlValue, ValidationExpression);
                var result = (m.Success && m.Index == 0 && m.Length == controlValue.Length);
                //Check to see if validation failed, if it did, add the class to the control to validate
                if (!result)
                {
                    var control = (WebControl) NamingContainer.FindControl(ControlToValidate);
                    //Didn't look into it too much, but the validators fire twice for some reason
                    if (!control.CssClass.Contains(CssControlErrorClass)) control.CssClass += " " + CssControlErrorClass;
                }
                return result;
            }
            catch
            {
                return true;
            }
        }
    }
