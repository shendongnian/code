     protected void CreateNewBuild_Click(object sender, EventArgs e)
        {           
			using (VODOMONTEntities context = new VODOMONTEntities())
			{
				Build b = new Build();
				BuildItem bi = new BuildItem();
				b.BuildSubject = txbSubject.Text;
				b.BuildNumber = txbBuildNumber.Text;
				b.City = txbCityBuild.Text;
				// b.BuildDate = txbBuildDate.Text;
				b.ClientId = Int32.Parse(ddlClient.SelectedValue);
				context.Builds.Add(b);                    
				for (int i = 0; i < (RowIndexNumber-1)/3; i++)
				{
					TextBox[] tb = new TextBox[RowIndexNumber];
					tb[i*3] = new TextBox();
					tb[i*3] = (TextBox)FindControl("txtBuisniesItem_Row" + (i * 3 + 1).ToString());
					bi.Name = tb[i*3].Text;
					tb[i*3+1] = new TextBox();
					tb[i*3+1] = (TextBox)FindControl("txtBuisniesItem_Row" + (i * 3 + 2).ToString());               
					bi.Quantity = Convert.ToInt32(tb[i * 3 + 1].Text);
					tb[i*3+2] = new TextBox();
					tb[i*3+2] = (TextBox)FindControl("txtBuisniesItem_Row" + (i * 3 + 3).ToString());
					bi.Price = decimal.Parse(tb[i * 3 + 2].Text.ToString());                                         
					bi.Build = b;
					context.BuildItems.Add(bi);
					context.SaveChanges();
				}
			}            
        }
		
        public int RowIndexNumber = 1;
        protected void Page_PreInit(object sender, EventArgs e)
        {
            List<string> keys = Request.Form.AllKeys.Where(key => key.Contains("txtBuisniesItem_Row")).ToList();
    
            foreach (string key in keys)
            {
                
                    this.CreateTextBox("txtBuisniesItem_Row" + RowIndexNumber);
                if (RowIndexNumber % 3 == 0)
                {
                    Literal lt = new Literal();
                    lt.Text = "<br />";
                    pnlTextBoxes.Controls.Add(lt);
                }
                RowIndexNumber++;
            }
        }
        
        protected void BtnAddNewBuildItem_Click(object sender, EventArgs e)
        {
            int index = pnlTextBoxes.Controls.OfType<TextBox>().ToList().Count + 1;
            this.CreateTextBox("txtBuisniesItem_Row" + index);
            this.CreateTextBox("txtBuisniesItem_Row" + (index + 1).ToString());
            this.CreateTextBox("txtBuisniesItem_Row" + (index + 2).ToString());
            Literal lt = new Literal();
            lt.Text = "<br />";
            pnlTextBoxes.Controls.Add(lt);
        }
        private void CreateTextBox(string id)
        {
            TextBox txt = new TextBox();
            txt.ID = id;
            txt.Attributes.Add("runat", "Server");
            pnlTextBoxes.Controls.Add(txt);
   
        }
