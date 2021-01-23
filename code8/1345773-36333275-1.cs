     protected void btnAddToCourse_OnClick_unat_(object sender, EventArgs e)
        {
            if (Session["Email"] != null)
            {
                foreach (RepeaterItem re in REPCOURSER.Items)
                {
                    Label rs = re.FindControl("lblprice") as Label;
                    Button Addcourse = re.FindControl("btnAddToCourse") as Button;
                    if (rs != null)
                    { 
                        if (rs.Text.ToLower() == "free" && Addcourse != null)
                        {
                            Courses courses = new Courses();
                            int res = courses.EnrollFreeCourses(new Course()
                             {
                                 CId = Convert.ToInt32(Addcourse.CommandArgument.ToString()),
                             }, new Users()
                             {
                                 id = Convert.ToInt64(Session["Id"].ToString())
                             });
    
                            Addcourse.Attributes.Add("disabled", "disabled");
                            Addcourse.Text = "Course Added To My Courses";
                        }
                        else
                        {
                            //Procedure for paid courses
                           
                        }
                    }
                  
                }
            }
            else
            {
                Master.LoginPopupExtender.Show();
            }
    
        }
