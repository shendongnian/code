            private void CreateDynamicControls(bool incrementRowCount = false)
        {
            int rowCount = 0;
            //initialize a session.
            rowCount = Convert.ToInt32(Session["clicks"]);
            if (incrementRowCount)
                rowCount++;
            Session["clicks"] = rowCount;
            //Create the textboxes and labels each time the button is clicked.
            for (int i = 0; i < rowCount; i++)
            {
                TextBox TxtBoxU = new TextBox();
                //TextBox TxtBoxE = new TextBox();
                Label lblU = new Label();
                //Label lblE = new Label();
                TxtBoxU.ID = "TextBoxU" + i.ToString();
                //TxtBoxE.ID = "TextBoxE" + i.ToString();
                lblU.ID = "LabelU" + i.ToString();
                //lblE.ID = "LabelE" + i.ToString();
                lblU.Text = "User " + (i + 1).ToString() + " : ";
                //lblE.Text = "E-Mail : ";
                //Add the labels and textboxes to the Panel.
                Panel1.Controls.Add(lblU);
                Panel1.Controls.Add(TxtBoxU);
                Panel1.Controls.Add(new LiteralControl("<br/>"));
                Panel1.Controls.Add(new LiteralControl("<br/>"));
            }
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            //If PostBack caused by btnAddCtrl, it will take care of adding controls
            if (Page.Request.Params.AllKeys.Contains("btnAddCtrl"))
                return;
            CreateDynamicControls();           
        }
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        protected void btnAddCtrl_Click(object sender, EventArgs e)
        {
            CreateDynamicControls(true);
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            foreach (TextBox textBox in Panel1.Controls.OfType<TextBox>())
            {
                
            }
        }
