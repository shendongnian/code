    		public Collection<DataTable> Tables { get; set; }
    		private void FillPages()
		    {
	    		for (int i = 0; i <= listView.Items.Count - 1; i++)
		    	{
                    // omitted for clarity
					DataTable data = new DataTable();
					grid.DataSource = data;
                    Tables.Add(data);
				}
			}
		}
