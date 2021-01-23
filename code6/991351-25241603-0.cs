        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRadioOnChecked();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetFeaturePackData();
            }
        }
        private void BindRadioOnChecked()
        {
            foreach (RepeaterItem item in Repeater_Select.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    CustomRadioButton customRbtn = (CustomRadioButton)item.FindControl("RadioButton_Select");
                    customRbtn.CheckedChanged += RadioButton_Select_OnCheckedChanged;
                }
            }
        }
