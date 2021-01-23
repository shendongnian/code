    protected void Page_Init(Object sender, EventArgs e)
    {
        RecreateControls();
    }
     private void RecreateControls()
     {
         int rowCount = Convert.ToInt32(Session["clicks"]);
         CreateControls(rowCount);
     }
     private void AddControl()
     {
         int rowCount = Convert.ToInt32(Session["clicks"]);
         CreateControls(1);
         Session["clicks"] = rowCount++;
     }
     private void CreateControls(int count)
     {
         for (int i = 1; i <= count; i++)
         {
             TextBox TxtBoxA = new TextBox();
             Label lblA = new Label();
             TxtBoxA.ID = "TextBoxA" + i.ToString();
             lblA.ID = "LabelA" + i.ToString();
             lblA.Text = "Label" + i.ToString() + ": ";
             Panel1.Controls.Add(lblA);
             Panel1.Controls.Add(TxtBoxA);
             Panel1.Controls.Add(new LiteralControl("<br />"));
         }
     }
     protected void Button1_Click(object sender, EventArgs e)
     {
         AddControl();
     }
