    class Lendet
    {
        public int kodiIlendes;
        public string emriIlendes;
        public static float sum;    
        public static int count;
    
        public Lendet()
    {
    count++;
    }
        private int nota;
        public int Nota {
            get {
                return nota;
            }
            set {
                if (value > 5 && value <= 10)
                {
                    sum =sum+value;
                    nota = value;
                }
                else {
                    Console.WriteLine("Nota duhet te jet me e > se 5 dhe nuk duhet te jet me e > se 10 ");
                }
            }
        }
    
    }
    
    static void Main(string[] args)
            {
                //create object1
                // create object2
               //......create object n
              Console.WriteLine(Lendet.sum/Lendet.count);
            }
