    public class Address
    {
    public string display_address { get; set; }
    public string building_number { get; set; }
    public string street_name { get; set; }
    public string city { get; set; }
    public string region { get; set; }
    public string postal_code { get; set; }
    public string country { get; set; }
    }
    public class Airport
    {
    public string airport_code { get; set; }
    public string airline_code { get; set; }
    public string terminal { get; set; }
    public string flight_number { get; set; }
    public int meet_greet { get; set; }
    }
    public class FromLocation
    {
    public double latitude { get; set; }
    public double longitude { get; set; }
    public Address address { get; set; }
    public string comment { get; set; }
    public Airport airport { get; set; }
    }
    public class Address2
    {
    public string display_address { get; set; }
    public string building_number { get; set; }
    public string street_name { get; set; }
    public string city { get; set; }
    public string region { get; set; }
    public string postal_code { get; set; }
    public string country { get; set; }
    }
    public class ToLocation
    {
    public double latitude { get; set; }
    public double longitude { get; set; }
    public Address2 address { get; set; }
    public object comment { get; set; }
    public object airport { get; set; }
    }
    public class Passenger
    {
    public string first_name { get; set; }
    public string last_name { get; set; }
    public string phone_number { get; set; }
    public bool is_primary_contact { get; set; }
    }
    public class Direction
    {
    public int kph { get; set; }
    public int heading { get; set; }
    }
    public class Vehicle
    {
    public string vehicle_type { get; set; }
    public string vehicle_id { get; set; }
    public string vehicle_plate { get; set; }
    public double latitude { get; set; }
    public double longitude { get; set; }
    public object eta_minutes { get; set; }
    public string make { get; set; }
    public string model { get; set; }
    public string color { get; set; }
    public string status { get; set; }
    public string driver_id { get; set; }
    public string driver_phone { get; set; }
    public string driver_first_name { get; set; }
    public string driver_last_name { get; set; }
    public Direction direction { get; set; }
    }
    public class RootObject
    {
    public string karhoo_ref { get; set; }
    public string booking_id { get; set; }
    public int datetime_scheduled_utc { get; set; }
    public string status { get; set; }
    public bool is_asap { get; set; }
    public bool as_directed { get; set; }
    public FromLocation from_location { get; set; }
    public ToLocation to_location { get; set; }
    public string notes { get; set; }
    public int passenger_count { get; set; }
    public int luggage_count { get; set; }
    public List<Passenger> passengers { get; set; }
    public Vehicle vehicle { get; set; }
    }
