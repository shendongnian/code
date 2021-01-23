    var mydb = new[]{
		new MyType{ MyTypeID = 1, ID = 2},
		new MyType{ MyTypeID = 1, ID = 3},
		new MyType{ MyTypeID = 2, ID = 5},
		new MyType{ MyTypeID = 2, ID = 4},
	};
	
	var vals = from mt in mydb
			   where mt.MyTypeID == 1 || mt.MyTypeID == 2
			   group mt by mt.MyTypeID into g
			   select new { MyTypeId = g.Key, MaxID = g.Max(x => x.ID)};
			   
