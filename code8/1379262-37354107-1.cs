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
