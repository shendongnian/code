        public class TriangleLogic
        {
        private double squareAdjacent = 0;
        private double squareOpposite = 0;
        private double squareSum = 0;
        public TriangleLogic()
        {
        }
        public double intRightAngle(int intAdjacent, int intOpposite)
        {
            squareAdjacent = Math.Pow(Convert.ToDouble(intAdjacent), 2);
            squareOpposite = Math.Pow(Convert.ToDouble(intOpposite), 2);
            squareSum = squareAdjacent + squareOpposite;
            return Math.Sqrt(squareSum);
        }
        public bool isAlreadyValidTriangle(int intAdj, int intOpp, List<Triangle> triangleList)
        {
            if (triangleList.Any(t => t.IntAdjacent == intAdj && t.IntOpposite == intOpp))
                return true;
            return triangleList.Any(t => t.IntAdjacent == intOpp && t.IntOpposite == intAdj);
        }
    }
