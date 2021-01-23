     protected void Button1_Click(object sender, EventArgs e)
     {
            DataAcess da = new DataAcess();
            List<info> lst = new List<info>();
            info inf = new info();
            inf.name = DropDownList1.Text;
            ////List<info> lsto = new List<info>();
            lst= da.Getdetails(inf.name);
           GridView1.DataSource = lst;
           GridView1.DataBind();
    }
