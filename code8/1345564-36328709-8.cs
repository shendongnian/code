    public class HomeWindowVm : BaseVm
    {
        public void SourceInitialized(object sender, EventArgs e)
        {
            var window = (Window)sender;
            var windowSource = PresentationSource.FromVisual(window) as HwndSource;
            ...
        }
    }
