    public void btn_1_Click(object sender, EventArgs e)
    {
        Person p = new Person
        {
            nbame = txt1.Text.ToString()
        };
        InsertPerson(p);
        Loadgrid();
    }
    public void InsertPerson(Person p)
    {
        DataClassesDataContext db = new DataClassesDataContext();
        Persontbl per = new Persontbl();
        per.name = p.nbame;
        db.Persontbls.InsertOnSubmit(per);
        db.SubmitChanges();
    }
    public void Loadgrid()
    {
        DataClassesDataContext db = new DataClassesDataContext();
        var result = from res in db.Persontbls select name;
        GRD1.DataSource = result;
        GRD1.DataBind();
    }
   
