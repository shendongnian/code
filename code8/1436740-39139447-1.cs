	public void BindMyData()
	{
		IRestResponse response = client.Execute(request);                 
		dynamic result = new JDynamic(response.Content);
		
		datagrid.DataSource = result.Select(s => 
			new MyCustomPoco{
				Id=s.Identifier, 
				Attribute=s.AnyOtherAttribute
			}
		);
		datagrid.DataBind();
	}
