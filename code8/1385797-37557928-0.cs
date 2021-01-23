            DataTable day = new DataTable();
    
            foreach (DataRow db in timeslots.Tables["schedules"].Rows)
            {
                string slot = db["sdates"].ToString();
                DateTime dt = DateTime.MinValue;
                var isValidDateTime = DateTime.TryParse(slot, out dt);
    
    
                if (!comboBox2.Items.Contains(slot))
                {
                	if(isValidDateTime)
                	{
                		comboBox2.Items.Add(dt.ToShortDateString());
                	}
                    
                }
            }
