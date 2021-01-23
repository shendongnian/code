		using System;
		using System.Collections.Generic;
		using System.Linq;
		using System.Web;
		using System.Web.UI;
		using System.Web.UI.WebControls;
		using System.Data.SqlClient;
		using System.Web.Configuration;
		using System.Data;
		namespace MySite
		{
			public partial class SiteMaster : MasterPage
			{
				protected void Page_Load(object sender, EventArgs e)
				{
					countmembers();
				}
				public void countmembers()
				{
				
					string strAllRegMembers = String.Empty;
					string strAllLogins = String.Empty;
					string strAllFailLogins = String.Empty;					
					string sql = @"SELECT (SELECT COUNT(MemberID) from MyTable where Mamber = 'Registered') AS AllRegMembers,
												(SELECT COUNT(MemberID) from MyTable where LoginStatus = 'ok') AS AllLogins,
												(SELECT COUNT(MemberID) from MyTable where LoginStatus = 'fail') AS AllFailLogins";
					string variable;
					using (var connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnString"].ConnectionString))
					using (var command = new SqlCommand(sql, connection))
					{
						connection.Open();
						using (var reader = command.ExecuteReader())
						{
							//Check the reader has data:
							if (reader.Read())
							{
								variable = reader.GetInt32(reader.GetOrdinal("AllRegMembers")).ToString();
							}
							// If you need to use all rows returned use a loop:
							while (reader.Read())
							{
								// Do something
								strAllRegMembers = reader.GetInt32(reader.GetOrdinal("AllRegMembers")).ToString();
								strAllLogins = reader.GetInt32(reader.GetOrdinal("AllLogins")).ToString();
								strAllFailLogins = reader.GetInt32(reader.GetOrdinal("AllFailLogins")).ToString();
							 
							}
						}
					}
					
					   Label.LabelCountMember.Text = strAllRegMembers;
								Label.LabelCountLogins.Text = strAllLogins;
								Label.LabelCountFailedLogins.Text = strAllFailLogins;
				}
			}
		}
		 
