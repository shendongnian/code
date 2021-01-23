    namespace guessing
    {
        public partial class Form1 : Form
        {
            Random rand = new Random();
            int rndm = new Random().Next(1, 13);
            // Or make it static.
            static Random rand = new Random();
            int rndm = Form1.rand.Next(1, 13);
            // Or a method
            private int GetRandomInteger()
            {
                return new Random().Next(1, 13);
                // or call your class level instance of Random
            }
