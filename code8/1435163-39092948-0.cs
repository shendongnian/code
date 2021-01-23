	public class abc
	{
	   public DateTime StartDate { get; set; }
	   public DateTime EndDate { get; set; }
	   
	   [NotMapped]
	   public double HourDifference
	   {
			get 
			{ 
				return (EndDate - StartDate).TotalHours;
			}
	   }
	}
