      protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
        }
    
        private void BindData()
        {
            List<string> values = ViewState["Colours"] as List<string>;
    
            if (values == null)
            {
                values = new List<string>
                {
                    "red",
                    "green",
                    "blue"
                };
            }
    
            ViewState["Colours"] = values;
    
            colours.DataSource = values;
            colours.DataBind();
        }
    
        protected void btnAddToListBox_Click(object sender, EventArgs e)
        {
            List<string> values = ViewState["Colours"] as List<string>;
            string newColour = txtNewColour.Text;
            bool exists = false;
    
            values.ForEach(i =>
                {
                    if (i == newColour)
                        exists = true;
                });
            
            if(!exists)
            {
                values.Add(txtNewColour.Text);
                this.DataBind();
            }
        }
