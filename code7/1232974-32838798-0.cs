    public class FacilityReservation
     {
                   public string facilityReservationID { get; set; }
                   public string facilityID { get; set; }
                   public DateTime startDateTime { get; set; }
                   public DateTime endDateTime { get; set; }
                   public string useShortDescription { get; set; }
                   public string useDescription { get; set; }
    }
     public class ReservationList
     {
                   public List<FacilityReservation> Reservations {get; set;}
    }
....
    ReservationList list = JsonConvert.DeserializeObject<ReservationList>(json);
    
        foreach(FacilityReservation res in list.Reservations)
         {
             FacilityReservation res = new FacilityReservation();
        
             //set all fields here
             res.FacilityReservationID = list.facilityReservationID;
        
                      db.Reservations.Add(res);
         }
