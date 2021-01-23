    // Custom comparer for the Test class
    class ProductComparer : IEqualityComparer<Test>
    {
        // Tests are equal if their IDs are equal.
        public bool Equals(Test x, Test y)
        {
            //Check whether the compared objects reference the same data.
            if (Object.ReferenceEquals(x, y)) return true;
            //Check whether any of the compared objects is null.
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;
            //Check whether the products' properties are equal.
            return x.Id == y.Id;
        }
        // If Equals() returns true for a pair of objects 
        // then GetHashCode() must return the same value for these objects.
        public int GetHashCode(Test test)
        {
            //Check whether the object is null
            if (Object.ReferenceEquals(test, null)) return 0;
            //Get hash code for the Name field if it is not null.
            int hashId = test.Id == null ? 0 : test.Id.GetHashCode();
            //Calculate the hash code for the test.
            return hashId;
            //Should be enough, but you can merge hashcodes of other fields in some way, for example:
            //int hashProperty = test.Property == null ? 0 : test.Property.GetHashCode();
            //return hashId ^ hashProperty;
        }
    }
