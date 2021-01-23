        protected void Page_Load(object sender, EventArgs e)
         {
              if (!IsPostBack)
                   txtData.Attributes.Add("onblur", "focuslost()");
         }
