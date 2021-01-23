    abstract class Pagination<T>
    {
        public virtual List<T> Items { get; set; }
    }
    class Tester : Pagination<string>
    {
        public void Test()
        {
            foreach (string item in this.Items)
            {
                // you have declared List<string> from Pagination<T>
            }
        }
    }
