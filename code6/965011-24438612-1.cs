    public enum BoatType : int
    {
        Kayak = 1,
        Canoe = 2
    }
    
    public class BoatReservation
    {
        public int ReservationID { get; set; }
        public BoatType ReservationBoatType { get; set; }
    }
    
    public class BoatTrailer
    {
        public List<BoatReservation> CanoeSlots = new List<BoatReservation>();
        public List<BoatReservation> RegularSlots = new List<BoatReservation>();
    
        public BoatTrailer()
        {
        }
    
        public bool AddBoat(BoatReservation b)
        {
            bool boatAdded = false;
            switch (b.ReservationBoatType)
            {
                case BoatType.Canoe:
                    if (CanoeSlots.Count() < 4)
                    {
                        CanoeSlots.Add(b);
                        boatAdded = true;
                    }
                    else
                    {
                        var reg = RegularSlots.Sum(x => Convert.ToInt16(x.ReservationBoatType));
                        if (reg <= 10)
                        {
                            RegularSlots.Add(b);
                            boatAdded = true;
                        }
                    }
                    break;
    
                case BoatType.Kayak:
                    {
                        var reg = RegularSlots.Sum(x => Convert.ToInt16(x.ReservationBoatType));
                        if (reg <= 11)
                        {
                            RegularSlots.Add(b);
                            boatAdded = true;
                        }
                    }
                    break;
            }
    
            return boatAdded;
        }
    
        public void RemoveBoat(BoatReservation b)
        {
            switch (b.ReservationBoatType)
            {
                case BoatType.Kayak:
                    if (RegularSlots.Contains(b))
                    {
                        RegularSlots.Remove(b);
                    }
                    break;
    
                case BoatType.Canoe:
                    if (RegularSlots.Contains(b))
                    {
                        RegularSlots.Remove(b);
                    }
                    else
                    {
                        if (CanoeSlots.Contains(b))
                        {
                            CanoeSlots.Remove(b);
                            if (RegularSlots.Where(fb => fb.ReservationBoatType == BoatType.Canoe).Count() > 0)
                            {
                                //Move Reservation From Regular to Canoe Only With Opening
                                BoatReservation mv = RegularSlots.FindLast(fb => fb.ReservationBoatType == BoatType.Canoe);
                                RegularSlots.Remove(mv);
                                CanoeSlots.Add(mv);
                            }
                        }
                    }
                    break;
            }
        }
    
        public string AvailableSlots()
        {
            string Output = string.Empty;
    
            int AvailableCanoeCnt = (4 - CanoeSlots.Count()) + ((12 - RegularSlots.Count()) / 2);
            int AvailableKayakCnt = (12 - RegularSlots.Count());
    
            Output = string.Format("Canoe Slots Left: {0}   Kayak Slots Left {1} ", AvailableCanoeCnt, AvailableKayakCnt);
    
            return Output;
        }
    }
