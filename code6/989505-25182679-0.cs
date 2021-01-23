    public class PointSeries
    {
        public List<Point> Points { get { return new List<Point>(); } }
    }
    
    public class CurveSeries
    {
        public List<Point> Points { get { return new List<Point>(); } }
    }
    
    public interface ISeriesWrapper
    {
        List<Point> Points { get; }
    }
    
    public class PointSeriesWrapper : ISeriesWrapper
    {
        public PointSeriesWrapper(PointSeries series)
        {
            _Series = series;
        }
    
        private PointSeries _Series;
    
        public List<Point> Points { get { return _Series.Points; } }
    }
    
    public class CurveSeriesWrapper : ISeriesWrapper
    {
        public CurveSeriesWrapper(CurveSeries series)
        {
            _Series = series;
        }
    
        private CurveSeries _Series;
    
        public List<Point> Points { get { return _Series.Points; } }
    }
    
    public static class SeriesWrapper
    {
        public static ISeriesWrapper Create(object series)
        {
            var pointSeries = series as PointSeries;
            if (pointSeries != null)
                return new PointSeriesWrapper(pointSeries);
    
            var curveSeries = series as CurveSeries;
            if (curveSeries != null)
                return new CurveSeriesWrapper(curveSeries);
    
            throw new NotSupportedException();
        }
    }
