    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["YourConfigKeyHere"].ConnectionString))
    			{
    				conn.Open();
    				using (SqlCommand cmd = new SqlCommand())
    				{
    					cmd.Connection = conn;
    					cmd.CommandText = "insert into newssph.ledger(Date, Reference, Rec_Qty, Iss_Qty, Bal_Qty, Med_ID) values(@Date, @Reference, @Rec_Qty, @Iss_Qty, @Bal_Qty, @Med_ID)";
    					cmd.CommandType = CommandType.Text;
    					cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = txtdate.Text; //Why are you using a textbox instead of a datepicker???
    					cmd.Parameters.Add("@Reference", SqlDbType.VarChar, 25).Value = comboBox4.Text; //Seriously??? comboBox4??? Give your controls names
    					cmd.Parameters.Add("@Rec_Qty", SqlDbType.Int).Value = this.txtrec.Text; //Why are you again using text? this should be a control that only allows numbers
    					cmd.Parameters.Add("@Iss_Qty", SqlDbType.Int).Value = this.txtissue.Text;
    					cmd.Parameters.Add("@Bal_Qty", SqlDbType.Int).Value = this.txtbal.Text;
    					cmd.Parameters.Add("@Med_ID", SqlDbType.Int).Value = this.comboBox4.Value;
    					cmd.ExecuteNonQuery();
    				}
    			}
