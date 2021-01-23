        private static PropertyInfo[] GetProperties(object obj)
        {
            return obj.GetType().GetProperties();
        }
   
        // -------
        foreach (var invalidCompany in mailMessageObject.InvalidCompanies)
        {
            var properties = GetProperties(invalidCompany);		
			foreach (var p in properties)
			{	
				string name = p.Name;
				if(propertiesThatNeedToBeDisplayed.Contains(name)
				{
					cell.InnerText = p.GetValue(invalidCompany, null);
                    row.Cells.Add(cell);
                    table.Rows.Add(row);
				}
			}
        }
