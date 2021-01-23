    //find all categories and populate category
			IEnumerable<string> categories = DS.Tables[0].AsEnumerable().Select(r => r.Field<string>("Category")).Distinct();
			//once the value in category combobox change 
			// inside Category_ComboBox_SelectionChanged
			string category = "Bill";
			//get rows with non null sub categories
			IEnumerable<DataRow> rows = DS.Tables[0].AsEnumerable().Where(r => r.Field<string>("Category").ToLower() == category.ToLower() && r["Sub_Category"] != DBNull.Value);
			if (rows.Count() == 0)
			{
				//disable sub category
			}
			else 
			{
				//get sub categories
				IEnumerable<string> sub_cats = rows.Select(r => r.Field<string>("Sub_category")).Distinct();
				
				//populate sub categories
			}
