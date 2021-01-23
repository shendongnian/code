    public class ExcitingResults {
        [Column(FriendlyName = "A", Rank = 1)]
        public int A { get; set; }
        [Column(FriendlyName = "B", Rank = 4)]
        public string B { get; set; }
        [Column(FriendlyName = "C", Rank = 3)]
        public DateTime C { get; set; }
        [Column(FriendlyName = "D", Rank = 2)]
        public string ComplexD {
            get { return SomeMethod("A", "B"); }
        }
    }
