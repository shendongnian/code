		private string BuildWhereClause(ListBox lb)
		{
			string WHEREclause = string.Empty;
			foreach(var itm in lb.SelectedItems)
			{
				if (WHEREclause  == string.Empty )
				{
					WHEREclause += " WHERE namakamera = '" + itm + "' ";
				}
				else
				{
					WHEREclause += " OR namakamera = '" + itm + "' ";
				}
			}
			return WHEREclause;
		}
