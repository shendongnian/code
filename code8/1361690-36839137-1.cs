    public class AvailableApartmentInfo
    {
    	public Apartment Apartment { get; set; }
    	public Room Room { get; set; }
    	public DateTime StartDate { get; set; }
    }
    var availableApartmentInfo =
    	from a in apartments
    	from ar in a.ApartmentRooms
    	from startDate in startDates
    	where !ar.OccupiedDatesBatches.Any(odb => 
            odb.OccupiedDates.Any(od => 
                od.Date >= startDate && od.Date < DbFunctions.AddDays(startDate, StayDuration)))
    	select new AvailableApartmentInfo { Apartment = a, Room = ar, StartDate = startDate };
