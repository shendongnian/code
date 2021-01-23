    enum SeatState {
        Free,
        // ...
    }
    class Seat {
        ICommand Buy { get; private set; }
        SeatState State { get; private set; }
        // ...
    }
    class Room {
        int Rows { get; private set; }
        int Colums { get; private set; }
        IEnumerable<Seat> Seats { get; private set; }
        // ...
    }
    class ViewModel : BaseClassImplementingINotifyPropertyChange {
        Room CurrentRoom {
            get { ... }
            private set { ... } // Raise event
        }
        ICommand LoadCurrentRoom { get; private set; }
    }
