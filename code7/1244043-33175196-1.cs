	public List<DataSet> GetDataSets(MyTypeQueryParameters parameters) {
		var query = db.DataSet.AsQueryable;
		if (parameters.Id != null) 
		{
			query = query.Where(x => x.Id == parameters.Id.Value);
		}
		else if (!string.IsNullOrWhitespace(MaterialName))
		{
			query = query.Where(x => x.TargetMaterial.Name == parameters.MaterialName);
		}
		return query.ToList();
	}
