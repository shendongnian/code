        public void GridView(Gridview gv,object datasource)
        {
            gv.DataSource = datasource;
            gv.DataBind();
        }
    Use it   
        GridView(gvCareer,bll.SelectCareerBLL());
