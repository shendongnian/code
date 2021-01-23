    public class PersonKey {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Zipcode { get; private set; }
        public PersonKey() {
            FirstName = null;
            LastName = null;
            Zipcode = int.MinValue;
        }
        public PersonKey(int Zipcode, string FirstName) : this() {
            this.FirstName = FirstName;
            this.Zipcode = Zipcode;
        }
        public PersonKey(string LastName, string FirstName) : this() {
            this.FirstName = FirstName;
            this.LastName = LastName;
        }
        public PersonKey(int Zipcode, string LastName, string FirstName) {
            this.Zipcode = Zipcode;
            this.LastName = LastName;
            this.FirstName = FirstName;
        }
        public List<string> KeyList {
            get {
                var keyLst = new List<string>();
                if (!String.IsNullOrEmpty(FirstName))
                    keyLst.Add("FirstName:" + FirstName);
                if (!String.IsNullOrEmpty(LastName))
                    keyLst.Add("LastName:" + LastName);
                if (Zipcode != int.MinValue)
                    keyLst.Add("Zipcode:" + Zipcode);
                return keyLst;
            }
        }
        public string Key {
            get {
                return MakeKey(KeyList.ToArray());
            }
        }
        public List<string[]> AllPossibleKeys {
            get {
                return CreateSubsets(KeyList.ToArray());
            }
        }
        List<T[]> CreateSubsets<T>(T[] originalArray) {
            List<T[]> subsets = new List<T[]>();
            for (int i = 0; i < originalArray.Length; i++) {
                int subsetCount = subsets.Count;
                subsets.Add(new T[] { originalArray[i] });
                for (int j = 0; j < subsetCount; j++) {
                    T[] newSubset = new T[subsets[j].Length + 1];
                    subsets[j].CopyTo(newSubset, 0);
                    newSubset[newSubset.Length - 1] = originalArray[i];
                    subsets.Add(newSubset);
                }
            }
            return subsets;
        }
        internal string MakeKey(string[] possKey) {
            return String.Join(",", possKey);
        }
