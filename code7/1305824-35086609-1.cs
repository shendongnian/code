    public class Camera1 : Camera
    {
        public override void SomeFunction(HardwareDriver driver)
        {
            // Very simple camera:
            driver.HandleAngle(this, 12.0);
            driver.GenerateModel();
        }
    }
    public class Camera2 : Camera
    {
        public override void SomeFunction(HardwareDriver driver)
        {
            // This camera understands focus
            driver.HandleAngle(this, 12.0);
            driver.HandleFocus(this, focus, this.focus * 1.2); 
            driver.GenerateModel();
        }   
    }
    public interface IDeviceVisitor
    {
        void HandleFocus(Camera camera, double focusValue, double realDistance);
        void HandleAngle(Camera camera, double angle);
        void GenerateModel();
        // [...]
        // etc
    }
    public abstract class Camera
    {
        public abstract void SomeFunction(HardwareDriver driver);
    }
