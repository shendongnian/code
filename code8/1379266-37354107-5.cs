    var cats = DS.Tables[0].AsEnumerable().Select(r => new { Key = r.Field<int>("Primary_Key"), Category = r.Field<string>("Category") }).ToList();
			foreach( var cat in cats)
			{
				//Add category and primary key to combo box
				//combox.addItem(cat.Key, cat.Category)
			}
            int id = 1; //Get form category combox
			DataSet DS = new DataSet(); // your dataset
			DataRow row = DS.Tables[0].AsEnumerable().Where(r => r.Field<int>("Id") == id).FirstOrDefault();
			if (row != default(DataRow))
			{
				if (row["sub_category"] != DBNull.Value)
				{
					//There is a sub category
				}
				else
				{
					//sub category is null
				}
			}
			else
			{
				//selected category id does not exists
			}
