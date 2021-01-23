    interface IBed {
        string Kind {get; set;}
        int Size {get; set;}
        bool HasBlankets {get; set;}
    }
    interface IHotelRoom {
        int RoomNumber {get; set;}
        IBed Bed {get;}
    }
    partial class HotelRoom : BaseModel, IHotelRoom {
        private class Bed : IBed {
            private HotelRoom room;
            internal Bed(HotelRoom room) {this.room = room;}
            public string Kind {
                get { return room.BedKind; }
                set { room.BedKind = value; }
            }
            ...
        }
        public IBed Bed {get;} = new Bed(this);
    }
