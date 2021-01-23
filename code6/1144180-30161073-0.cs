        for (int i = 0; i < Gvassignsubject.Rows.Count; i++)
        {
            DropDownList ddlfaculty = (DropDownList)Gvassignsubject.Rows[i].FindControl("ddlfaculty");
            string facultyname = ddlfaculty.SelectedValue;
            if (!string.Equals(ddlfaculty.SelectedValue, "Please Select"))
            {
                string batch = ddlbatches.SelectedValue;
                string subject = r.Cells[0].Text;
                TextBox txthour = (TextBox)Gvassignsubject.Rows[i].FindControl("txthour");
                string sethour = txthour.Text;
                con2.Open();
                SqlCommand cmd = new SqlCommand("insert into assign (batch,facultyname,sethour,subject)values(@batch,@facultyname,@sethour,@subject)", con2);
                cmd.Parameters.AddWithValue("@batch", batch);
                cmd.Parameters.AddWithValue("@subject", subject);
                cmd.Parameters.AddWithValue("@facultyname", facultyname);
                cmd.Parameters.AddWithValue("@sethour", sethour);
                cmd.Connection = con2;
                cmd.ExecuteNonQuery();
                con2.Close();
            }
        }
