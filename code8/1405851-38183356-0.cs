    public void bindStudentID()
    {
        try
        {
            ArrayList a = new ArrayList();
    
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT studentId FROM tbStudent",     con);
            SqlDataReader dr = cmd.ExecuteReader();
    
            while (dr.Read())
            {
                a.Add(dr["studentId"]);
            }
            comboBox1.DataSource = a;
    
            ArrayList aa = new ArrayList();
            SqlCommand cmdd = new SqlCommand("SELECT SemesterID FROM tbSemester     Where StudentID='" + comboBox1.Text + "'", con);
            dr = null;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                aa.Add(drr["SemesterID"]);
                
            }
            comboBox2.DataSource = aa;
            con.Close();
    
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
        }
    }
