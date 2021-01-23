    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data.SqlClient;
    using System.Data;
    using System.Configuration;
    
    namespace Blog
    {
        public partial class index : System.Web.UI.Page
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["blogconnection"].ToString());
            protected void Page_Load(object sender, EventArgs e)
            {
                con.Open();
                string allimage;
                string qry="select * from images";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlDataReader dr =cmd.ExecuteReader();
    
                if (dr.HasRows)
                {
                    while(dr.Read())
                    {
                       if (!string.IsNullOrEmpty(Convert.ToString(dr["Image_Path"])))
                       {                                             
                            Image img = new Image();
                            img.ImageUrl = dr["Image_Path"].ToString();
                            img.AlternateText = dr["Image_Path"].ToString();
                            form1.Controls.Add(img);                                         
                       }
                    }
               }
               con.Close();
           }               
        }
    }
