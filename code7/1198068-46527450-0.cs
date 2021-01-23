     StringBuilder SQLtext = new StringBuilder();
                SqlCommandBuilder sqlBuilder = new SqlCommandBuilder();
                string MyColumn = sqlBuilder.QuoteIdentifier(Radio_range.SelectedValue);
                SQLtext.AppendLine(" With ctemp as( ");
                SQLtext.AppendLine(" select convert(varchar(10),sysDate,102) sysDate,convert(varchar(10),WeekDate,102) WeekDate,[Month],[Quarter],[Year] ");
                SQLtext.AppendLine(" from sysCalendar ");
                SQLtext.AppendLine(" where sysdate<=(select max(nominal_date) from ATTENDANCE_AGENT_T) ");
                SQLtext.AppendLine(" and sysDate>=dateadd(MONTH,-12,getdate()) ");
                SQLtext.AppendLine(" ) ");
                SQLtext.AppendFormat(" select distinct {0} as mydate from ctemp order by {1}  desc ", MyColumn, MyColumn);
                string constr = ConfigurationManager.ConnectionStrings["CIGNAConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(SQLtext.ToString()))
                    {
                        cmd.CommandType = CommandType.Text;
                        //cmd.Parameters.AddWithValue("@mydate", Radio_range.SelectedValue);
                        cmd.Connection = con;
                        con.Open();
                        DropDownList_Date.DataSource = cmd.ExecuteReader();
                        DropDownList_Date.DataTextField = "mydate";
                        DropDownList_Date.DataValueField = "mydate";
                        DropDownList_Date.DataBind();
                        con.Close();
                    }
                }
