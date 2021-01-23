    using MSSQLConnector;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Web;
    using System.Web.Services.Description;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace WebApplication1.eyeofheaven
    {
    
        public partial class SearchCustomer : System.Web.UI.Page
        {
            public static string query = null;
            private int cnt;
            private DataSet selectedData;
            private DataTable dt;
            private MSConnector connector = new MSConnector();
    
            protected void Page_Load(object sender, EventArgs e)
            {
            }
            protected void Button1_Click(object sender, EventArgs e)
            {
                //Function for BindRepeater 
                BindRepeater();
            }
            protected void Button2_Click(object sender, EventArgs e)
            {
               this.repeater.Visible = false;
               this.linkPrevious.Visible = false;
               this.linkNext.Visible = false;
               this.search.Value = "";
               this.Country.Value = "select";
               this.Currency.Value = "selected";
            }
    
            //This property will contain the current page number 
            public int PageNumber
            {
                get
                {
                    if (ViewState["PageNumber"] != null)
                    {
                        return Convert.ToInt32(ViewState["PageNumber"]);
                    }
                    else
                    {
                        return 0;
                    }
                }
                set { ViewState["PageNumber"] = value; }
            }
    
            //Asp:ListView
            private void BindRepeater()
            {
                //ConnectionString for accessing into MSSql
                connector.ConnectionString = "SERVER=xbetasql,52292;UID=username;Password=secret;DATABASE=ATDBSQL;";
                
                //Get the values from id's
                string customer = (this.search.Value);
                string country = (this.Country.Value);
                string idcurrency = (this.Currency.Value);
    
                //Conditions for query
                if (customer != "")
                {
                    query = "select * from customer where idcustomer = '" + customer + "'";
                }
                else if (country != "select")
                {
                    if (idcurrency != "selected")
                    {
                        query = "select * from customer where country = '" + country + "' and idcurrency = '" + idcurrency + "'";
                    }
                    else
                    {
                        query = "select * from customer where country = '" + country + "'";
                    }
                }
                else if (idcurrency != "selected")
                {
                    query = "select * from customer where idcurrency = '" + idcurrency + "'";
                }
                else if (customer == "")
                {
                    Response.Write("<script>alert('No Id Inputted, Data Not Found.')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Invalid input.')</script>");
                }
                //DataSet and DataTable (get the data and display it into asp:repeater
                selectedData = connector.ExecuteQuery(query);
                dt = selectedData.Tables[0];
    
                //Set PageData Settings
                PagedDataSource pagedData = new PagedDataSource();
                pagedData.DataSource = dt.DefaultView;
                pagedData.AllowPaging = true;
                //Set to 2 pages to be viewed
                pagedData.PageSize = 2;
                pagedData.CurrentPageIndex = PageNumber;
                //Count to 2 pages to appear when clicking next or previous
                int vcnt = dt.DefaultView.Count / pagedData.PageSize;
    
                if (PageNumber == 1)
                {
                    linkPrevious.Visible = false;
                }
                else if (PageNumber < 1)
                {
                    linkPrevious.Visible = false;
                }
                else if (PageNumber > 0)
                {
                    linkPrevious.Visible = true;
                }
                
                if (PageNumber == vcnt)
                {
                    linkNext.Visible = false;
                }
                //Hide previous and next if it is firstpage and lastpage
                else if(PageNumber < vcnt)
                {
                    linkNext.Visible = !pagedData.IsLastPage;
                    linkPrevious.Visible = !pagedData.IsFirstPage;
                }
            
               //Binding the repeater 
               if (dt.Rows.Count > 0)
                {
                    repeater.Visible = true;
                    repeater.DataSource = pagedData;
                    repeater.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('No Data Found.')</script>");
                }
            }
    
            protected void linkNext_Click(object sender, EventArgs e)
            {
                linkNext.Visible = true;
                PageNumber += 1;
                BindRepeater();
            }
            protected void linkPrevious_Click(object sender, EventArgs e)
            {
                linkPrevious.Visible = true;
                PageNumber -= 1;
                BindRepeater();
            }
    
        }
    }
