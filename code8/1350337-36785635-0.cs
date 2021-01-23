                dt.Columns.Add("ID");
                dt.Columns.Add("Fist_Name");
                dt.Columns.Add("last_Name");
                dt.Columns.Add("Address");
                DataRow dr1 = dt.NewRow();
                dr1[0] = TextBox1.Text;
                dr1[1] = TextBox2.Text;
                dr1[2] = TextBox3.Text;
                dr1[3] = TextBox4.Text;
                dt.Rows.Add(dr1);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                Session["Data"] = dt;
            }
            else
            {
                dt = (DataTable)Session["Data"];
                DataRow dr1 = dt.NewRow();
                dr1[0] = TextBox1.Text;
                dr1[1] = TextBox2.Text;
                dr1[2] = TextBox3.Text;
                dr1[3] = TextBox4.Text;
                dt.Rows.Add(dr1);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                Session.Remove("Data");
                Session["Data"] = dt;
               
            }
