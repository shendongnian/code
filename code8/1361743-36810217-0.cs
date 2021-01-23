    public class ReusableList<T> : List<T>
    {
        private List<T> backup;
        public void Clear(bool purge = false)
        {
            if (purge)
                backup?.Clear();
            else
                backup = this.ToList();
            base.Clear();
        }
        public new void Clear()
        {
            this.Clear(false);
        }
    }
