				protected void GridView1_PreRender(object sender, EventArgs e)
				{
				string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
				using (SqlConnection con = new SqlConnection(constr))
				{
				using (SqlCommand cmd = new SqlCommand())
				{
				cmd.CommandText = "SELECT [OrderNo],[Name],[Email],[Date],[Amount],[Status] FROM dbo.tbl_Orders";
				cmd.Connection = con;
				using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
				{
				DataTable dt = new DataTable();
				sda.Fill(dt);
				GridView1.DataSource = dt;
				GridView1.DataBind();
				if (GridView1.Rows.Count > 0)
				{
				//Replace the <td> with <th> and adds the scope attribute
				GridView1.UseAccessibleHeader = true;
				//Adds the <thead> and <tbody> elements required for DataTables to work
				GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
				//Adds the <tfoot> element required for DataTables to work
				GridView1.FooterRow.TableSection = TableRowSection.TableFooter;
				//GridView1.DataSource = GetData();  //GetData is your method that you will use to obtain the data you're populating the GridView with
				}
				}
				}
				}
				}
