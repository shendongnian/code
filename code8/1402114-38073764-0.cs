       public void Bind()
            {
                SqlCommand cmd = new SqlCommand(@"select AttendanceDate,SUBSTRING(convert(varchar,intime,113),1,11) as [InTimeD],SUBSTRING(convert(varchar,InTime,113),13,19) as [IntimeT],
                InDeviceId,OutTime,OutTime,OutDeviceId, dbo.MinutesToDuration(duration) as Duration,Status from dbo.AttendanceLogs
                    where  EmployeeId='" + empIdtxt.Text + "' and year(AttendanceDate)=" + ddlYear.SelectedItem.Value +
                                         "  and month(AttendanceDate)=" + ddlmnt.SelectedValue + " order by AttendanceDate desc", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd,con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
    
                GridView1.ControlStyle.Font.Size = 10;
    
            }
