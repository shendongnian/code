    public class AlarmData
    {
    	public string Alarm0 { get; set; }
    	...
    	public string Alarm99 { get; set; }
    }
    
    public class Alarms
    {
        private List<AlarmData> alarmData = new List<AlarmData>();
    
        public void SetAlarms(DataTable AlarmsTable) 
        {
    		this.alarmData.Clear();
            foreach (DataRow row in AlarmsTable.Rows)
    		{		
    			var newData = new AlarmData();
                newData.Alarm0 = Convert.ToString(AlarmsTable.Rows[currentRow]["Alarm0"]);
                ...
                newData.Alarm99 = Convert.ToString(AlarmsTable.Rows[currentRow]["Alarm99"]);
    			
    			this.alarmData.Add(newData);
            }
        }
    
        public bool AlarmsOk()
        {
            //Check if alarms are OK, return true/false
        }
    }
