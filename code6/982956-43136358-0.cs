    i did it like this when I had to apply this to all tables:
    private static void AlterTableType(List<Table> t)
		{
			foreach (Table table in t)
			{
				foreach (TableRow row in table.Descendants<TableRow>())
				{
					TableRowProperties trP = new TableRowProperties();
					CantSplit split = new CantSplit();
					trP.Append(split);
					row.AppendChild(trP);
				}
			}
		}
