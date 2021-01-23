    class Foo {
        public List<string> Bars { get; set; }        
        public Foo(string bars) { 
            try
            {
               if(bars == null){ bars = "" } //Whatever value bars should be if null, in this case an empty string.
            {
            catch(Exception)
            {
               throw;
            }
        }
        public void Translate()
        {
            // Should I check with a null && count > 0?
            if (Bars != null && Bars.Count > 0)
            {
                [...]
            }
        }
    }
