	static void Main(string[] args)
	{
		var p = new DataTable("P");
		var pp1 = new DataColumn("P1", typeof(int));
		var pp2 = new DataColumn("P2", typeof(int));
		pp2.DefaultValue = DBNull.Value;
		p.Columns.AddRange(new[] { pp1, pp2 });
		p.PrimaryKey = new[] { pp1, pp2 };
		pp2.AllowDBNull = true;
		var c = new DataTable("C");
		var cc1 = new DataColumn("C1", typeof(int));
		var cp1 = new DataColumn("P1", typeof(int));
		var cp2 = new DataColumn("P2", typeof(int));
		c.Columns.AddRange(new[] { cc1, cp1, cp2 });
		c.PrimaryKey = new[] { cc1 };
		c.Constraints.Add(new ForeignKeyConstraint(new[] { pp1, pp2 }, new[] { cp1, cp2 }));
		var s = new DataSet() { EnforceConstraints = true };
		s.Tables.AddRange(new[] { p, c });
	
		// the following no longer throws InvalidConstraintException
		p.Rows.Add(1, null);
		c.Rows.Add(1, 1, null);
    }
