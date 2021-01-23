    private T LookupData<T>(Dictionary<string, T> dict, string key)
	{
		if(key == null)
			return null;
		
		T result;
		
		if(dict.TryGetValue(key, out result))
			return result;
		else
			return null;
		
	}
	List<Document> doc = SystemOperationManager.GetSalesByMemberLucene(ConfigurationManager.GetIndexPath(), memberId).ToList();
	Dictionary<string, Department> _allDepartments = DepartmentManager.GetAll().ToDictionary(s => s.Id.ToString(), s => s);
	Dictionary<string, User> _allUsers = UserManager.GetAll().ToDictionary(s => s.Id.ToString(), s => s);
	Dictionary<string, Product> _allProducts = ProductManager.GetAll().Where(x => x.CustomType == 2).ToDictionary(s => s.Id.ToString(), s => s);
	List<SystemOperation> so = doc.Select(s => new SystemOperation
	{
		ObjStylist = LookupData<User>(_allUsers, s.Get("ObjStylist")),
		ObjDepartment = LookupData<Department>(_allDepartments, s.Get("ObjDepartment")),
		ObjProduct = LookupData<Product>(_allProducts, s.Get("ObjProduct"))
		//TotalPointsCollected = decimal.Parse(s.Get("TotalPointsCollected")),
		//PointsAccumulated = decimal.Parse(s.Get("PointsAccumulated"))
	}).ToList();
	_result = so;
	rgList.DataSource = _result;
	rgList.DataBind();
