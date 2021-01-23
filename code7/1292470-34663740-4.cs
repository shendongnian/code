        public enum TrueOrFalse
        {
            True,
            False
        }
        public static IEnumerable<TrueOrFalse> BoolValues {
            get {
                List<TrueOrFalse> allValues = new List<TrueOrFalse>();
                foreach (var value in Enum.GetValues(typeof(TrueOrFalse))){
                    allValues.Add((TrueOrFalse)(value));
                }
    
                return allValues.AsEnumerable();
            }
        }
