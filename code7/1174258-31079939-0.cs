    public class SomeEnumerable : IEnumerable<string>
    {
        private string[] values = new string[] { "foo", "bar" };
        
        #region Enumerator
        
        private IEnumerable<string> GetValues()
        {
            foreach(var s in values)
            {
                yield return s;
            }
        }
        
        #endregion Enumerator
        
        #region IEnumerable implementation
    
        public IEnumerator<string> GetEnumerator() {
            return GetValues().GetEnumerator();
        }
        #endregion
        #region IEnumerable implementation
        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
        #endregion
    }
