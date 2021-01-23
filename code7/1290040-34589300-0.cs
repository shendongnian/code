    private bool filterCompanyInfos(object o){
    	//Function which return true if selected info and filter (name, town, code,...) corresponds to the object o (casted as a CompanyModel)
    	//I let you write this part, should be like the filterCompanyType method.
    }
    
    private bool filterCompanyType(object o){
    	criteria.Clear();
    
    	if (currentCheckBox.IsChecked == true && nonCurrentCheckBox.IsChecked == false)
    	{
    		criteria.Add(new Predicate<CompanyModel>(x => x.CurrentStatus == 1));
    	}
    	else if (nonCurrentCheckBox.IsChecked == true && currentCheckBox.IsChecked == false)
    	{
    		criteria.Add(new Predicate<CompanyModel>(x => x.CurrentStatus == 0));
    	}
    	else if (nonCurrentCheckBox.IsChecked == true && currentCheckBox.IsChecked == true)
    	{
    		criteria.Add(new Predicate<CompanyModel>(x => (x.CurrentStatus == 1 || x.CurrentStatus == 0)));
    	}
    	//.... All other criterias here
    	
    	CompanyModel company = o as CompanyModel;
    	bool isIn = true;
    	if (criteria.Count() == 0)
    		return isIn;
    	isIn = criteria.TrueForAll(x => x(company));
    	return isIn;
    }
    
    private bool FilterCompany(object o){
    	return filterCompanyType(o) && filterCompanyInfos(o)
    }
    
    
    public void ApplyFilter(CollectionView companyCollectionView){
    	CompanyICollectionView.Filter = this.FilterCompany;
    	//do some other stuff like selected index ...
    }
