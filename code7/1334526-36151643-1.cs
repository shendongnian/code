    private void LoadFactories(int CityId)
            {
                FactoryCls objFactory = new FactoryCls();
    
                DataTable dtFactory = objFactory.FactoriesByCity(CityId);
    
                ddlFactory.DataSource = dtFactory;
                ddlFactory.DataTextField = "Name";
                ddlFactory.DataValueField = "ID";
                ddlFactory.DataBind();
                ddlFactory.SelectedIndex = 0;
            }
