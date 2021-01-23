    using TravelSalesClass;
    using System.Drawing;
    namespace ConsoleApplication1
    {
        class Program
        {
        static void Main(string[] args)
        {
            SalesAlgorithm salesAlgorithm = new SalesAlgorithm();
            Point[] points = salesAlgorithm.Points;
            //draw a line between 2 points
            salesAlgorithm.DrawLine(points[0], points[1]);
            //clear all points and lines
            salesAlgorithm.Clear();
            //clear lines
            salesAlgorithm.ClearLines();           
            
        }
    }
