    class Program
    {
        static void Main(string[] args)
        {
            var array = new Matrix();
            array[1,0] = "cat";
            array[0,1]="dog";
            Console.WriteLine(array[0, 1]); //Prints "dog"
            array[0, 1] = null; //Removes dog
        }
    }
    class Matrix
    {
        private Dictionary<string,Object> Data = new Dictionary<string,object>();
        public object this[int x, int y]
        {
            get
            {
                return Data[String.Join(",", new[] { x, y }) ];
            }
            set
            {
                string key = String.Join(",", new[] { x, y });
                if(value==null)
                    Data.Remove(key);
                else
                    Data[key] = value;
            }
        }
    }
