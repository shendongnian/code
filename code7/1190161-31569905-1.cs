	void ChangeName<T>(IEnumerable<T> list) where T : IHaveName
    { 
        foreach (T item in list)
        {
            item.Name = ChangeName(project.Name);
        }
    }
    void ChangeNamesAndSubmitChanges(dataModel dataModel)
    { 
	    ChangeName(dataModel.Projects);
		ChangeName(dataModel.Employees);
        dataModel.SubmitChanges();
    }
