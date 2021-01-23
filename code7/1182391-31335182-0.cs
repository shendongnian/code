    protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
            }
        }
        protected void btn_Registration_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
                conn.Open();
    			string checkuser = "select count(*) from UserData where Username = '" + txtUser.Text + "'";
                SqlCommand scm = new SqlCommand(checkuser, conn);
                int temp = Convert.ToInt32(scm.ExecuteScalar().ToString());
                if (temp == 1) // check if user already exist.
                {
                    Response.Write("User already existing");
                }
    			else
    			{
    				string insertQuery = "insert into UserData(Username,Firstname,Lastname,Email,Password,CustomerType,DeliveryAddress,Zip,ContactNumber)values(@Username,@Firstname,@Lastname,@Email,@Password,@CustomerType,@DeliveryAddress,@Zip,@ContactNumber)";
    				SqlCommand scm = new SqlCommand(insertQuery, conn);
    				scm.Parameters.AddWithValue("@Username", txtUser.Text);
    				scm.Parameters.AddWithValue("@Firstname", txtFN.Text);
    				scm.Parameters.AddWithValue("@Lastname", txtLN.Text);
    				scm.Parameters.AddWithValue("@Email", txtEmail.Text);
    				scm.Parameters.AddWithValue("@Password", BusinessLayer.ShoppingCart.CreateSHAHash(txtPW.Text));
    				scm.Parameters.AddWithValue("@CustomerType", RadioButtonList1.SelectedItem.ToString());
    				scm.Parameters.AddWithValue("@DeliveryAddress", txtAddress.Text);
    				scm.Parameters.AddWithValue("@Zip", txtZip.Text);
    				scm.Parameters.AddWithValue("@ContactNumber", txtContact.Text);
    
    				scm.ExecuteNonQuery();
    				Session["Contact"]= txtContact.Text;
    				Session["Email"] = txtEmail.Text;
    				Session["DeliveryAddress"] = txtAddress.Text;
    				label_register_success.Text = ("Registration Successful!");
    				//Response.Redirect("Home.aspx");
    			}
                conn.Close();
            }
            catch (Exception ex)
            {
                Response.Write("Error:" + ex.ToString());
            }
        }
