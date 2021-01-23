    public class CustomScrollViewer : ScrollViewer
    {
        protected override void OnManipulationDelta(ManipulationDeltaEventArgs e)
        {
            base.OnManipulationDelta(e);
            e.ReportBoundaryFeedback(new ManipulationDelta(new Vector(0, 0), 0, new Vector(0, 0), new Vector(0, 0)));
        }
    }
