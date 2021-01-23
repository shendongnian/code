    class Results {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    class ResultsEqualityComparer : IEqualityComparer<Results> {
        public bool Equals(Results res1, Results res2) {
            return (res1.FirstName == res2.FirstName && res1.LastName == res2.LastName);
        }
        public int GetHashCode(Results res) {
            int hCode = res.FirstName.Length ^ res.LastName.Length;
            return hCode.GetHashCode();
        }
    }
