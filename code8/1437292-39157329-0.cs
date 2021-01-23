    interface IPersistableHotelRoom { 
        int BedSize {get; set;}
    }
    
    public class HotelRoom : IPersistableHotelRoom {
        int IPersistableHotelRoom.BedSize { get; set; }
    
        public class Bed {
            private HotelRoom room; // set this in the nested class constructor, not shown
            public int Size { get { return room.BedSize; } }
        }
        public Bed Bed {get;}
        public HotelRoom() {
            this.Bed = new Bed(this);
        }
    }
