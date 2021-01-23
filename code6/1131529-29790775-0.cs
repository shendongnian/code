    foreach (GridViewRow row in Grd.Rows)
    {
       TextBox txtAmt = (TextBox)row.FindControl("txtAmount");
       string Id = Grd.DataKeys[row.RowIndex].Value.ToString();
       for (int i = 0; i < dt.Rows.Count; i++)
       {
          if (Id == dt.Rows[i]["ID"].ToString())
          {
             //do your logic here.
          }
       }
    }
