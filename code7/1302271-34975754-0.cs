        class Program
        {
            static void Main(string[] args)
            {
                object[,] entities = {
                        { new Player(), new Wall(), new Bomp(), new Gift()},
                        { new Player(), new Wall(), new Bomp(), new Gift()},
                        { new Player(), new Wall(), new Bomp(), new Gift()},
                        { new Player(), new Wall(), new Bomp(), new Gift()}
                };
            }
        }
        public class Player
        {
        }
        public class Wall
        {
        }
        public class Bomp
        {
        }
        public class Gift
        {
        }
