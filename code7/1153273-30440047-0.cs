    public class Data : IComparable
    {
        public int Component { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Argument { get; set; } 
        public int CompareTo(object obj) {
            var other = obj as Data;
            if(other == null)
            {
                throw new ArgumentException("Object is not Data");
            }
            else
            {
                //compare the two instances here...
            }
        }
    }
