                questionDT = new DataTable();
            questionDT.Columns.Add(new DataColumn("NameQuestion", typeof(string)));
            questionDT.Columns.Add(new DataColumn("DetailsQuestion", typeof(string)));
            questionDT.Columns.Add(new DataColumn("UserId", typeof(int)));
			var q = new Question();
            int counQ = 0;
            for (int i=1; i<=100000; i++)
            {
				foreach (var x in GetUsers()) 
				{
					++counQ;
					var dr = questionDT.NewRow();
					dr["NameQuestion"] = "TestQuestion" + counQ;
					dr["DetailsQuestion"] = "TestQuestion" + counQ;
					dr["UserId"] = x;
					questionDT.Rows.Add(dr);
				}
			}
			using (var c = new SqlConnection(connectionstring))
			{
				c.Open();
				using (var bcp = new SqlBulkCopy(c))
				{
					bcp.BatchSize = 10000;
					bcp.ColumnMappings.Add("NameQuestion", "NameQuestion");
					bcp.ColumnMappings.Add("DetailsQuestion", "DetailsQuestion");
					bcp.ColumnMappings.Add("UserId", "UserId");
					bcp.DestinationTableName = "Questions";
					bcp.BulkCopyTimeout = 0;
					bcp.WriteToServer(questionDT);
				}
				c.Close();
			}
