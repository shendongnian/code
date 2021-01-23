    public class HeatmapImage : MapImageLayer
    {
        protected override void UpdateImage(
            double west, double east, double south, double north, int width, int height)
        {
            BitmapSource bitmap = ... // create heatmap here
            UpdateImage(west, east, south, north, bitmap);
        }
    }
