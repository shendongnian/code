    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class ExpandablePropertyAttribute : ActionFilterAttribute
    {
        #region [ Constants ]
        private const string ODATA_EXPAND = "$expand=";
        #endregion
        #region [ Fields ]
        private string _propertyName;
        private bool _alwaysExpand;
        #endregion
        #region [ Ctor ]
        public ExpandablePropertyAttribute(string propertyName, bool alwaysExpand = false)
        {
            this._propertyName = propertyName;
            this._alwaysExpand = alwaysExpand;
        }
        #endregion
        #region [ Public Methods - OnActionExecuting ]
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);
            var uriBuilder = new UriBuilder(actionContext.Request.RequestUri);
            var queryParams = uriBuilder.Query.TrimStart('?').Split(new char[1] { '&' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            int expandIndex = -1;
            for (var i = 0; i < queryParams.Count; i++)
            {
                if (queryParams[i].StartsWith(ODATA_EXPAND, StringComparison.Ordinal))
                {
                    expandIndex = i;
                    break;
                }
            }
            if (expandIndex >= 0 || this._alwaysExpand)
            {
                if (expandIndex < 0)
                {
                    queryParams.Add(string.Concat(ODATA_EXPAND, this._propertyName));
                }
                else
                {
                    queryParams[expandIndex] = queryParams[expandIndex] + "," + this._propertyName;
                }
                uriBuilder.Query = string.Join("&", queryParams);
                actionContext.Request.RequestUri = uriBuilder.Uri;
            }
        }
        #endregion
    }
