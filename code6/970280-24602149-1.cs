    /// <summary>
    ///     When Required the action cannot be invoked unless the form has
    ///     the required form-action value
    /// </summary>
    public enum FormActionMode
    {
        Required,
        Normal
    }
    public class FormActionAttribute : ActionMethodSelectorAttribute
    {
        public const string HTTP_FORM_NAME = "form-action"; 
        public FormActionAttribute(params string[] values)
            : this(FormActionMode.Required, values)
        {
        }
        /// <summary>
        ///     Constructor to specify the FormActionMode
        /// </summary>
        /// <param name="mode">
        ///     Specify Normal to allow invocation of the action with out the matching form action. Defaults to
        ///     Required
        /// </param>
        /// <param name="values"></param>
        public FormActionAttribute(FormActionMode mode, params string[] values)
        {
            Values = values;
            Mode = mode;
        }
        public string[] Values
        {
            get;
            private set;
        }
        public FormActionMode Mode
        {
            get;
            private set;
        }
        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {
            string action = GetAction(controllerContext);
            if (string.IsNullOrEmpty(action))
                return true;
            return Values.Any(x => x.Equals(action, StringComparison.CurrentCultureIgnoreCase)) ||
                   methodInfo.Name.Equals(action, StringComparison.CurrentCultureIgnoreCase);
        }
        /// <summary>
        ///     Returns the form action from the current context. Returns null if there is no action
        /// </summary>
        /// <param name="controllerContext"></param>
        /// <returns>Null if there is no action</returns>
        internal static string GetAction(ControllerContext controllerContext)
        {
            string action = controllerContext.HttpContext.Request.Params[HTTP_FORM_NAME];
            if (string.IsNullOrEmpty(action))
                return null;
            //Stops errors on multiple value submissions
            //this will choose the first value in the form
            if (action.IndexOf(",") > -1)
                return action.Split(',')[0];
            return action;
        }
    }
