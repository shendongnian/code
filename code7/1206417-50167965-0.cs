        //***************************************************************************
        public static partial class RndExtensions
        //***************************************************************************
        {
        //-------------------------------------------------------------
        public static double NextDouble(this Random rnd, double from, double to, double step)
        //-------------------------------------------------------------
        {
            var delta = to - from;
            var nbOfSteps = (int)(delta / step);
            var randomStep = rnd.Next(0, nbOfSteps);
            return step*randomStep + from; 
        }
        //-------------------------------------------------------------
        public static double Next(this Random rnd, int from, int to, int step)
        //-------------------------------------------------------------
        {
            var delta = to - from;
            var nbOfSteps = (int)(delta / step);
            var randomStep = rnd.Next(0, nbOfSteps);
            return step * randomStep + from;
        }
        }
