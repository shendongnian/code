    var ds = new DataSet();
    if ((ddldept.SelectedValue == "all") && (ddldesig.SelectedValue != "all"))
    {
        using (var con = new SqlConnection(constring))
        {
            con.Open();
            string desig = ddldesig.SelectedValue;
            DateTime mydate;
            mydate = Convert.ToDateTime(tbfrom.Text);
            string from = Convert.ToString(mydate);
            mydate = Convert.ToDateTime(tbto.Text);
            string to = Convert.ToString(mydate);
            using (var cmddeptall = new SqlCommand("select * from registration where Department IN('Computer Science Engineering','Mechanical Engineering','Electrical And Electronics','Electronics And Communication','Civil Engineering','Science And Humanity') AND PostAppliedFor='" + desig + "' AND (RegisteredDate BETWEEN '" + from + "' AND '" + to + "')", con))
            {
                using (var da = new SqlDataAdapter(cmddeptall))
                {
                    da.Fill(ds, "registration");
                }
            }
        }
    }
    else if ((ddldept.SelectedValue == "all") && (ddldesig.SelectedValue == "all"))
    {
        // Code Here
    }
    else if ((ddldept.SelectedValue != "all") && (ddldesig.SelectedValue != "all"))
    {
        // Code Here
    }
