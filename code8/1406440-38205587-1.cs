    	private void AccessData()
		{
			foreach(var table in Tables)
			{
				MessageBox.Show(table.Rows[0]["SomeColumn"].ToString());
			}
		}
