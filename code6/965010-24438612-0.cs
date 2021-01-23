    public enum BoatType: int
    {
        Kayak = 1,
        Canoe = 2
    }
    
    public class BoatTrailer
    {
        public List<BoatType> CanoeSlots = new List<BoatType>();
        public List<BoatType> RegularSlots = new List<BoatType>();
    
        public BoatTrailer()
        {
        }
    
        public bool AddBoat(BoatType b)
        {
            bool boatAdded = false;
            switch (b)
            {
                case BoatType.Canoe:
                    if (CanoeSlots.Count() < 4)
                    {
                        CanoeSlots.Add(b);
                        boatAdded = true;
                    }
                    else
                    {
                        var reg = RegularSlots.Sum(x => Convert.ToInt16(x));
                        if (reg <= 10)
                        {
                            RegularSlots.Add(b);
                            boatAdded = true;
                        }
                    }
                    break;
    
                case BoatType.Kayak:
                    {
                        var reg = RegularSlots.Sum(x => Convert.ToInt16(x));
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
    
        public void RemoveBoat(BoatType b)
        {
            switch (b)
            {
                case BoatType.Kayak:
                    if (RegularSlots.Contains(BoatType.Kayak))
                    {
                        RegularSlots.Remove(RegularSlots.FindLast(x => x == BoatType.Kayak));
                    }
                    break;
    
                case BoatType.Canoe:
                    if (RegularSlots.Contains(BoatType.Canoe))
                    {
                        RegularSlots.Remove(RegularSlots.FindLast(x => x == BoatType.Canoe));
                    }
                    else
                    {
                        if (CanoeSlots.Contains(BoatType.Canoe))
                        {
                            CanoeSlots.Remove(CanoeSlots.FindLast(x => x == BoatType.Canoe));
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
