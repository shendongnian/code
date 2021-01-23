    interface IPosition { 
        int Size { get; }
    }
    class Position { //in 3rd party lib
        public int Size {
            get { return 5; }
        }
    }
    class RealPosition : IPosition { //use this as your real object instead of using Position directly
        private Position position;
        public RealPosition(Position position) {
            this.position = position;
        }
        public int Size {
            get { return position.Size; }
        }
    }
    class MockPosition : IPosition { //use this for testing
        public int Size{ get; set; }
    }
    public class Program {
        static void Main(string[] args) {
            var pos = new MockPosition { Size = 7 };
            Console.WriteLine(Calc(pos));    //prints 14
            Console.ReadLine();
        }
        static int Calc(IPosition pos) { //change your method signature to work with interface
            return pos.Size * 2;
        }       
    }
