    SqlDataSource SqlDataSourceFormulariDaAppr = new SqlDataSource();
                SqlDataSourceFormulariDaAppr.ID = "SqlDataSourceFormulariDaAppr";
                this.Page.Controls.Add(SqlDataSourceFormulariDaAppr);
                SqlDataSourceFormulariDaAppr.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                SqlDataSourceFormulariDaAppr.SelectCommand = "SELECT * FROM table WHERE userID = " + DropDownListUtenti.SelectedValue + "";
                SqlDataSourceFormulariDaAppr.DataBind();
                GridViewFormulariDaAppr.DataSource = SqlDataSourceFormulariDaAppr;
                GridViewFormulariDaAppr.DataBind();
