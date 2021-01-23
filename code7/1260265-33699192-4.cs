    var user = GetSomeuser(1);
    var truckID = user.Details.FromJson<DriveDetails>().TruckID; //fake extension method to deserialize json string back to object
    public class DriverDetails
    {
       pubic int TruckID...
       public string SomeOtherDetails...
    }
