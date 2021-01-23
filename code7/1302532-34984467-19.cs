	public class MainViewModel : ViewModelBase, IMouseCaptureProxy
    {
		public event EventHandler Capture;
		public event EventHandler Release;
		public void OnMouseDown(object sender, MouseCaptureArgs e) {...}
		public void OnMouseMove(object sender, MouseCaptureArgs e) {...}
		public void OnMouseUp(object sender, MouseCaptureArgs e) {...}
	}
