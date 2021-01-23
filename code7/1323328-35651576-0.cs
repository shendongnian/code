	public class Car : DataRecord
	{
		// An event to execute when the record is deleted
		public CarEvent OnDelete { get; set; }
	
		public void Delete()
		{
			this.DeleteRecord(); // Deletes this record from ex. the database
		
			if (OnDelete)
			{
				OnDelete(this); // Executes the event
			}
		}
	}
