    public class StringLengthEqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return x.Length == y.Length;
        }
        public int GetHashCode(string obj)
        {
            return obj.Length;
        }
    }
            string [] array1 = new string [] { "foo", "bar", "yup" };
            string[] array2 = new string[] { "dll" };
            int diffCount;
            diffCount = 0;
            foreach (var diff in array1.Except(array2, new StringLengthEqualityComparer()))
            {
                diffCount++;
            }
            Debug.Assert(diffCount == 0); // No assert.
            diffCount = 0;
            foreach (var diff in array1.Except(array2))
            {
                diffCount++;
            }
            Debug.Assert(diffCount == 0); // Assert b/c diffCount == 3.
