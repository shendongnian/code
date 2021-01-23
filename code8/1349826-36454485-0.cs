    class Comparer : IEqualityComparer<Test>
    {
        public bool Equals(Test x, Test y)
        {
            return string.Equals(x.testname, y.testname) && string.Equals(x.errormessage, y.errormessage);
        }
    
        public int GetHashCode(Test obj)
        {
            string name = string.Format ("{0}{1}", obj.testname, obj.errormessage);
            int hash = 7;
            for (int i = 0; i < name.Length; i++)
            {
                hash = hash * 31 + name[i];
            }
    
            return hash;
        }
    }
