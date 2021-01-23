	public class MainViewModel : ViewModelBase, IMouseCaptureProxy
    {
		public event EventHandler Capture;
		public event EventHandler Release;
		public void OnMouseDown(object sender, MouseCaptureArgs e) {...}
		public void OnMouseMouse(object sender, MouseCaptureArgs e) {...}
		public void OnMouseUpobject sender, MouseCaptureArgs e) {...}
	}
