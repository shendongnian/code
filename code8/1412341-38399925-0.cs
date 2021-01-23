        public const string SESSION_ERROR = "SessionError";
		public const string SESSION_SUCCESS = "SessionSuccess";
		protected override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			base.OnActionExecuting(filterContext);
			ViewBag.Error = HttpContext.Session[SESSION_ERROR];
			ViewBag.Success = HttpContext.Session[SESSION_SUCCESS];
			HttpContext.Session[SESSION_ERROR] = string.Empty;
			HttpContext.Session[SESSION_SUCCESS] = string.Empty;
		}
