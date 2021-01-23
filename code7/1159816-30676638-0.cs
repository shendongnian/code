    private IList<IAppointment> _list {get; set;}
    public Appointments()
    {
		_list = Load() ?? new List<IAppointment>();
    }
    public List<IAppointment> Load()
    {
		try
		{
        	var json = File.ReadAllText(".Appointments.json");
			var list = JsonConvert.DeserializeObject<List<IAppointment>>(json);
			return list;
		}
		catch
		{
			return null;
		}
	}
    public bool Save()
    {
		try
		{
        	var json = JsonConvert.SerializeObject(_list);
			File.WriteAllText(".Appointments.json",json);
			return true;
		}
		catch
		{
			return false;
		}
    }
