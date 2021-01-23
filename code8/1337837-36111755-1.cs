    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data.Sql;
    using System.Data.SqlClient;
    using System.Configuration;
    using System.Data;
    
    namespace WebApplication_Test1
    {
        public partial class _Default : Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                //connect to the database now 
                if (Page.IsPostBack == false)
                {
                    //we store the database connect information in Web.Config
                    //so we retrieve the connection string from the Web.Config
                    String mydatabaseconnection = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
                    SqlConnection con = new SqlConnection(mydatabaseconnection);
                    //select all records from the grades table via
                    //here you can replace this table 'Grades' with your table's schema  
                    String myquery = "Select * From Grades";
                    SqlCommand command = new SqlCommand(myquery);
                    command.CommandType = System.Data.CommandType.Text;
                    command.Connection = con;
                    try
                    {
                        //open the connection to the database 
                        con.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
    
                        DataSet ds = new DataSet("Grades");
    
                        //populate the data into a DataSet 
                        adapter.Fill(ds);
    
                        //ddl_StudentName.DataSource = ds.Tables[0];
                        ddl_StudentName.DataSource = ds;
                        ddl_StudentName.DataBind(); // bind the data from the table now 
                                                    // this is were DataTextField and DataValueField will get mapped
                                                    // to database fields student_name and student_id
    
                        //to handle the drop down change use event SelectedIndexChanged
                        ddl_StudentName.SelectedIndexChanged += Ddl_StudentName_SelectedIndexChanged;
    
                        //gets the first student from the database and populate the textbox
                        Student_ID.Text = ds.Tables[0].Rows[0]["student_id"].ToString();
    
                        //close connection to database 
                        con.Close();
                    }
                    catch (Exception ex)
                    {
    
                    }
                }else
                {
                    ddl_StudentName.SelectedIndexChanged += Ddl_StudentName_SelectedIndexChanged
                }
            }
    
            private void Ddl_StudentName_SelectedIndexChanged(object sender, EventArgs e)
            {
                //when we change the dropdownlist we need to get the student id and set it to the textbox
                DropDownList mydropdownlist = sender as DropDownList;
                Student_ID.Text = mydropdownlist.SelectedValue;
     
            }
        }
    }
