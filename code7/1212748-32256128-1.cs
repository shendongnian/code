    public class ChartFeature : IFeature {
        ...
        public void RenderOn(IReportWriter report) {
           // Draw the chart based on the primitives.
           report.DrawLine(..., ...);
           ...
        }
    }
