    protected void btnSave_Click(object sender, EventArgs e)
            {  string Check=string.Empty;
                string BranchID = dpbranch.SelectedValue;
                string ClassID = dpClassName.SelectedValue;
                string SectionID = dpsection.SelectedValue;
                TestSchool.SchoolBusinessLyr.SchoolBizClient Attendance = new TestSchool.SchoolBusinessLyr.SchoolBizClient();
                System.Collections.Generic.Dictionary<string, string> AssignStudentAttendance;
                DataSet ds = new DataSet();
                foreach (GridViewRow row in gdstudentattendance.Rows)
                {
                    //Create new dictionary for each row
                    AssignStudentAttendance = new System.Collections.Generic.Dictionary<string, string>();
                    String cellText = row.Cells[0].Text;
                    String RegisterNo = row.Cells[2].Text;
                    int rowIndex = 0;
                    for (int i = 0; i < gdstudentattendance.Rows.Count; i++)
                    {
    
                        //extract the TextBox values
                        CheckBox StudentAttendance = (CheckBox)gdstudentattendance.Rows[i].Cells[i].FindControl("chkattendance");
                      if(StudentAttendance.Checked==true)
                      {
                          Check="true";
                      }
                      else
                      {
                           Check="false";
                      }
                        AssignStudentAttendance.Add("BranchID", BranchID);
                        AssignStudentAttendance.Add("ClassID", ClassID);
                        AssignStudentAttendance.Add("SectionID", SectionID);
                        AssignStudentAttendance.Add("StudentID", cellText.ToString());
                        AssignStudentAttendance.Add("RegisterNo", RegisterNo.ToString());
                        AssignStudentAttendance.Add("Attendance", Check.ToString());
                        Attendance.InsertStudentAttendance(AssignStudentAttendance);
    
                    }
                }
    
            }
