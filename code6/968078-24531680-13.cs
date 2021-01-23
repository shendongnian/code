    public class Original
    {
        public void DoOriginal() { }
    }
    public class OriginalWrapper
    {
        private Original original;
        public OriginalWrapper(Original original)
        {
            this.original = original;
        }
        public void DoOriginal() { original.DoOriginal();}
        public void DoOriginalWrapper() { }
    }
