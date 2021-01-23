    for (i = 0; i < dtspmonthyear.Rows.Count; i++)
    {
        foreach (var item in cmbEmp_Name.Items.Where(x => x.Selected))
        {
            if (item.Text.Contains("PROCESSED"))
            {
                //CF.ExecuteQuerry("exec Emp_Resign_Allocate_Leave '" + str_emp_sel + "','" + dtspmonthyear.Rows[0]["month"].ToString() + "', '" + dtspmonthyear.Rows[0]["year"].ToString() + "'");
            }
            else
            {
             // not going in else for `PENDING`
            }
        }
    }
