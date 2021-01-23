	protected void addListItemsToPage() {
		// wrap this in a using statement so the connection is closed and disposed
		using(EndophthalmitisDBDataContext dbContext = new EndophthalmitisDBDataContext())
		{
			// replaced your wrong for statement with a foreach because you do not need a for statement (you are not using the indexer in a way that added any benifit)
			foreach(var hospital in dbContext.Hospital_Datas)
				ListItem li = new ListItem();
				li.Text = hospital.Hospital_Name;
				li.Value = hospital.HospitalID;
				hospitalDDL.Items.Add(li);
			}
			
			// OR you could write it as a single statement
			hospitalDDL.AddRange(dbContext.Hospital_Datas.Select(hospital => new ListItem(){Text = hospital.Hospital_Name, Value = hospital.HospitalID}));
		}
	}
