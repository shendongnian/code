    protected void Page_Load(object sender, EventArgs e)
            {
                string ID = Request.QueryString["id"];
                RecipeID.Text = ID;
    
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0; AttachDbFilename=C:\Users\Donald\Documents\Visual Studio 2013\Projects\DesktopApplication\DesktopApplication\Student_CB.mdf ;Integrated Security=True");
                con.Open();
                try
                {
                        
                    SqlDataAdapter sda = new SqlDataAdapter("Select Recipe_Name, Recipe_Description, Recipe_Instructions FROM Recipe Where Recipe_ID= @recipeid", con);
                    sda.SelectCommand.Parameters.Add("@recipeid", SqlDbType.Int).Value = RecipeID.Text;
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
    
                    if (dt.Rows.Count > 0)
                        nameTxt.Text = dt.Rows[0][0].ToString();
                    descriptionTxt.Text = dt.Rows[0][1].ToString();
                    instructionsTxt.Text = dt.Rows[0][2].ToString();
    
                    dt.Clear();
    
                }
                catch (Exception ex)
                {
    
                }
    
                con.Close();
            }
