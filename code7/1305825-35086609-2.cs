    public class Camera1 : Camera
    {
        public override Generic.CameraSelect CameraType { get; set; } = "CAM1";
    }
    public class Camera2 : Camera
    {
        public override Generic.CameraSelect CameraType { get; set; } = "CAM2";
    }
    public abstract class Camera
    {
        public abstract Generic.CameraSelect CameraType { get; set; }
        public void SomeFunction()
        {
            HardwareDriver.Function(this);
        }
    }
