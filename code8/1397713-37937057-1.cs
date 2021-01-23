    GridViewRow row = GridView1.Rows[GridView1.Rows.Count-1];
    Button Edit = ((Button)row.FindControl("btnedit")).Text;
    Button Add = ((Button)row.FindControl("btnadd")).Text;
    Edit.visible =false;
    Add.Visible =true; 
