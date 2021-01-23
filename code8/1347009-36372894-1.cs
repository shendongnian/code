    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data.SqlClient;
    using System.Data;
    using System.Data.SqlClient;
    using System.Data;
    
    public partial class Default12 : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        string str;
        protected void Page_Load(object sender, EventArgs e)
        {
            str = @"Data source=INSPIRATION\SQLEXPRESS; Initial Catalog=ComputerPedia; Integrated security= true";
            con = new SqlConnection(str);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("Select Comment from CommentTable", con);
            dr = cmd.ExecuteReader();
        }
        protected void Button_Click(object sender, EventArgs e)
        {
    if (reader.HasRows) // to check whether there are comments or not in your database
    {
          int commentIndexForLabel = 1;
        while (reader.Read())
        {      
           // Response.Write(dr[0].ToString()); 
                Label l = new Label();
                l.ID = "l" + commentIndexForLabel.ToString() ; //modified
                l.Text = (string)dr["Comment"]; //modified
               
                CommentPlaceHolder.Controls.Add(l);
                commentIndexForLabel ++;
                //UpdatePanel1.Update(); This is not required
        }
    }
    else
    {
        // do whatever you want to do if there are no comments
    }
       
     
                
        }
    }
