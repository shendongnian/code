    List<Foo> foos = new List<Foo>();
    private FillList()
    {
         //...
    }
    private int CurrentPage
        {
            get
            {
                object obj = ViewState["CurrentPage"];
                if (obj != null)
                    return (int)obj;
                return 0;
            }
            set
            {
                ViewState["CurrentPage"] = value;
            }
        }
    private void RptBind(int curPage, int pageSize)
    {
        rptFoos.DataSource = foos.Skip(pageSize * curPage).Take(pageSize);
        rptFoos.Databind();
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
         CurrentPage += 1;
         RptBind(CurrentPage, 10);
    }
