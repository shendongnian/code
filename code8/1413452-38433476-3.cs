    void readSettings()
    {
		DataTable dt = new DataTable();
		dt.ReadXml(@"filename_goes_here");
		for(int i = 0; i < dt.Rows.Count; i++)
		{
			switch(dt.Rows[i][0])
			{
				case "Speed":
					try
					{
						_timer.Interval=Int32.Parse(dr.Rows[i][1]);
					}
					catch
					{
						// we've got a problem !
					}
					
					break;
				default:break;
			}
		}
    }
