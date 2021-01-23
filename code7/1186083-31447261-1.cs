    protected void Button1_Click(object sender, EventArgs e)
    {
       DataTable dt = new DataTable();
       DataRow dr;
       dt.Columns.Add("Name");
       dt.Columns.Add("Address");
       dt.Columns.Add("Number");
       foreach (GridViewRow gr in GridView1.Rows)
       {
          //using gridviewrow
          if (gr.RowType == DataControlRowType.DataRow)
          {                    
             dr = dt.NewRow();
             dr["Name"] = gr.Cells[0].Text;
             dr["Address"] = gr.Cells[1].Text;
             dr["Number"] = gr.Cells[2].Text;
             dt.Rows.Add(dr);
          }
      }
      GridView1.DataSource = dt;
      GridView1.DataBind();
    }
