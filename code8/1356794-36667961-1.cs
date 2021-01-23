    class Program
    {
        static void Main(string[] args)
        {
            var array = new Matrix();
            array[1,0] = "cat";
            array[0,1]="dog";
            Console.WriteLine(array[0, 1]);
            array[0, 1] = null;
    
        }
    }
    class Matrix
    {
        private Dictionary<string,Object> Data = new Dictionary<string,object>();
        public object this[int x, int y]
        {
            get
            {
                return Data[this.GetKey(x,y)];
            }
            set
            {
                string key = this.GetKey(x, y);
                if(value==null)
                    Data.Remove(key);
                else
                    Data[key] = value;
            }
        }
        private string GetKey(int x, int y)
        {
            return String.Join(",", new[] { x, y });
        }
    }
