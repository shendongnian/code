    static bool showed = false; 								// <---- This line
    private void DisplayTextBox(Control con)
	{
		if (rad1.Checked)
		{
			foreach (Control c in con.Controls)
			{
				if (c is TextBox)
				{
					((TextBox)c).Enabled = false;
					txtCCode1.Enabled = true;
					txtGrade1.Enabled = true;
				}
				else
				{
					DisplayTextBox(c);
				}
			}
		}
		showed = false; 										// <---- This line
    }
    private void calculate(Control con)
    {
        foreach (Control c in con.Controls)
        {
            if (c is TextBox)
            {
                if (c.Text == "")
                {
                    if (!showed) 								// <---- This line
					{											// <---- This line
						showed = true; 							// <---- This line
						DialogResult x = new DialogResult();
						x = MessageBox.Show("TextBox cannot be Empty");
						if (x == DialogResult.OK)
							txtCCode1.Focus();
					}											// <---- This line
                }
                else
                {
                    int totalCredHours = 0;
                    CalcTotalCredHours(credHour1, credHour2, credHour3, credHour4, credHour5, credHour6, ref totalCredHours);
                    courseGP1 = CalcCourseGradePoint(credHour1, gradePoint1);
                    courseGP2 = CalcCourseGradePoint(credHour2, gradePoint2);
                    courseGP3 = CalcCourseGradePoint(credHour3, gradePoint3);
                    courseGP4 = CalcCourseGradePoint(credHour4, gradePoint4);
                    courseGP5 = CalcCourseGradePoint(credHour5, gradePoint5);
                    courseGP6 = CalcCourseGradePoint(credHour6, gradePoint6);
                    double totalCGP = CalcTotalCGP(courseGP1, courseGP2, courseGP3, courseGP4, courseGP5, courseGP6);
                    double gpa = CalcGPA(totalCGP, totalCredHours);
                    lblGPA.Text = gpa.ToString("N");
                }
            }
            else
            {
                calculate(c);
            }
        }              
    }
