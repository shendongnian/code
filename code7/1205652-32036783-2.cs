        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            HttpContext context = base.Context;
            HttpRequest request = context.Request;
            string pageName = System.IO.Path.GetFileNameWithoutExtension(request.RawUrl);
            if (pageName != "Default")
            {
                if (context.Session["phoneCheckboxList"] != null)
                    context.Session.Remove("phoneCheckboxList");
            }
        }
