            protected void LoadOptions()
            {
                DataTable CardCode = new DataTable();
                string id, name, newName, name2;
                SqlConnection connection = new SqlConnection("Data Source=adfsadf;Initial Catalog=TestDatabse;Persist Security Info=True;User ID=asd;Password=asdf");
                using (connection)
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT T1.CardCode , T1.CardName, T2.OpprId,T1.CntctPrsn, T2.CprCode,T2.MaxSumLoc  FROM OCRD T1 left  join OOPR T2 on T1.CardCode=T2.CardCode" , connection);
                    adapter.Fill(CardCode);
                    if (CardCode.Rows.Count > 0)
                    {
                        for (int i = 0; i < CardCode.Rows.Count; i++)
                        {
    
                            id = CardCode.Rows[i]["CardCode"].ToString();
                            name = CardCode.Rows[i]["CardName"].ToString();
                            newName = id + " ---- " + name;
                            //name2 = id;
                            DropDownList1.Items.Add(new ListItem(newName, id));
    
                            //*******HERE*****//
                            DropDownList2.DataSource = CardCode;
                            DropDownList2.DataBind();
                            DropDownList2.DataValueField = "CardCode";
                            DropDownList2.DataTextField = "CntctPrsn";
                            
                            //*******HERE*****//
                        }
                    }
                }
            }
    
            protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
            {
    
    
                string selected = DropDownList1.SelectedItem.Value;
                SqlConnection connection = new SqlConnection("Data Source=mydtasrc;Initial Catalog=TestDatabs;Persist Security Info=True;User ID=asf;Password=asdfgh");
                using (connection)
                {
                    // SqlCommand theCommand = new SqlCommand("SELECT CardCode, CardName, OpprId, CprCode,MaxSumLoc  FROM OOPR WHERE CardCode = @CardCode", connection);
    
                    SqlCommand theCommand = new SqlCommand("SELECT T1.CardCode , T1.CardName, T2.OpprId, T1.CntctPrsn,T2.CprCode  FROM OCRD T1 left  join OOPR T2 on T1.CardCode=T2.CardCode  where T1.CardCode=@CardCode", connection);
    
    
                    connection.Open();
                    theCommand.Parameters.AddWithValue("@CardCode", selected);
                    theCommand.CommandType = CommandType.Text;
    
                    SqlDataReader theReader = theCommand.ExecuteReader();
    
                    if (theReader.Read())
                    {
                        this.TextBox1.Text = theReader["CardCode"].ToString();
                        this.TextBox2.Text = theReader["CardName"].ToString();
                        this.TextBox5.Text = theReader["CprCode"].ToString();
                        this.TextBox3.Text = theReader["OpprId"].ToString();
                        //*******AND HERE*****//
                        this.DropDownList2.Value = selected; 
                   
                        //*******AND HERE*****//
                    }
                    connection.Close();
                }
    
            }
    
    
    
           
