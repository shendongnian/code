    public class MyScrollViewer : ScrollViewer {
      protected override HitTestResult HitTestCore(PointHitTestParameters hitTestParameters) {
        return null;
      }
    }
