        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateStates();
            }
        }
        private void PopulateStates()
        {
            var statesNotInUS = (from s in _repository
                where s.CountryCode != "USA"
                select s).ToList();
            StateDropDownList.DataSource = statesNotInUS;
            StateDropDownList.DataBind();
        }
