    public class Metrics
    {
    protected static Metrics_instance;
    double width;
    double height;
    static Metrics()
    {
        _instance = new Metrics();
    }
    protected Metrics()
    {
    }
    public static bool IsOrientationPortrait() 
    {
        return _instance.height > _instance.width;
    }
    public static void SetSize(double width, double height)
    {
        _instance.width = width;
        _instance.height = height;
    }
}
