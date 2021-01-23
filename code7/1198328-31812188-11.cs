    public class Tracker {
        private int _level;
        public BeginEnd<int> Track()
        {
            return new BeginEnd<int>(_level++,
                lev1 => {
                   Debug.WriteLine("Begin " + lev1);
                },
                lev2 => {
                   Debug.WriteLine("End " + lev2);
                   --_level;
                });
        }
    }
    //...
    Tracker t = new Tracker();
    using (var n0 = t.Track()) {
        using (var n1 = t.Track()) {
        }
        using (var n2 = t.Track()) { }
    } 
    // prints:
    // Begin 0
    // Begin 1
    // End 1
    // Begin 1
    // End 1
    // End 0
    
