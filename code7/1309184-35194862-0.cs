    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data.SqlClient;
    using System.Data;
    using System.Configuration;
    
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
    
            if (!IsPostBack)
            {
            }
    
        }
    
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationDatabaseConnectionString"].ConnectionString);
                conn.Open();
                string checkuser = "SELECT count(*) FROM Customers WHERE CustUserName='" + txtCustUserName.Text + "'";
                SqlCommand com = new SqlCommand(checkuser, conn);
                int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
			    conn.Close();
                if (temp > 0)
                {
                    Response.Write("User already exists");
                }
                else
                {
					conn.Open();
					string insertQuery = "INSERT into Customers (CustFirstName, CustLastName, CustAddress, CustCity, CustProv, CustPostal, CustCountry, CustHomePhone, CustBusPhone, CustEmail, CustUserName, CustPassword) values (@custFirstName ,@custLastName ,@custAddress ,@custCity ,@custProv ,@custPostal, @custCountry ,@custHomePhone ,@custBusPhone ,@custEmail ,@custUserName ,@custPassword)";
					SqlCommand com = new SqlCommand(insertQuery, conn);
					com.Parameters.AddWithValue("@custFirstName", txtCustFirstName.Text);
					com.Parameters.AddWithValue("@custLastName", txtCustLastName.Text);
					com.Parameters.AddWithValue("@custAddress", txtCustAddress.Text);
					com.Parameters.AddWithValue("@custCity", txtCustCity.Text);
					com.Parameters.AddWithValue("@custProv", txtCustProv.Text);
					com.Parameters.AddWithValue("@custPostal", txtCustPostal.Text);
					com.Parameters.AddWithValue("@custCountry", txtCustCountry.Text);
					com.Parameters.AddWithValue("@custHomePhone", txtCustHomePhone.Text);
					com.Parameters.AddWithValue("@custBusPhone", txtCustBusPhone.Text);
					com.Parameters.AddWithValue("@custEmail", txtCustEmail.Text);
					com.Parameters.AddWithValue("@custUsername", txtCustUserName.Text);
					com.Parameters.AddWithValue("@custPassword", txtCustPassword.Text);
					com.ExecuteNonQuery();
					Response.Redirect("Manager.aspx");
					Response.Write("Registration is successful" );
					conn.Close();
				}
            }
            catch(Exception ex)
            {
                Response.Write("Error:"+ex.ToString());
            }
        }
    }
