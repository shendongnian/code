    protected void Page_Load(object sender, EventArgs e)
            {
                if (Session["New"] != null)
                {               
                    if (Session["Basket"] != null)
                    {
                        ShoppingBasket.Visible = true;                    
                        redPnl.Visible = false;                   
                        RecipeID.Text += Session["Basket"].ToString();
    
                        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0; AttachDbFilename=C:\Users\Donald\Documents\Visual Studio 2013\Projects\DesktopApplication\DesktopApplication\Student_CB.mdf ;Integrated Security=True");
                        con.Open();
    
                        SqlDataAdapter sda = new SqlDataAdapter("Select Ingredient_Name, Ingredient_Amount From Ingredient Where Recipe_ID=@RecipeID", con);
                        sda.SelectCommand.Parameters.Add("@RecipeID", SqlDbType.VarChar).Value = RecipeID.Text;
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        IngredientsList.Text = string.Empty;
                        for (int i = 0; i<dt.Rows.Count ;i++)
                        {
                            IngredientsList.Text += dt.Rows[i].ItemArray[0].ToString();
                            IngredientsList[i].Text += " | " + dt.Rows[i].ItemArray[1].ToString() + Enviornment.NewLine;
                            dt.Clear();
                        }
                    }
    
                }
    
            }
