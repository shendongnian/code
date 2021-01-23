    public interface IRobot
    {
        // Fields
        float speed { get; }
        float position { get; set; }
        // Implementation specific functions.
        // Similar to an override function.
        void OnMove(float direction);
    }
    public static class IRobotHelper
    {
        // Common code for all IRobot implementations. 
        // Similar to the body of a virtual function, only it always gets called.
        public static void Move(this IRobot iRobot, float direction)
        {
            // All robots move based on their speed.
            iRobot.position += iRobot.speed * direction;
            // Call the ImplementationSpecific function
            iRobot.OnMove(direction);
        }
    }
    // Pro-Guns robot.
    public class Robocop : IRobot
    {
        public float position { get; set; }
        public float speed { get; set;}
        private void Shoot(float direction) { }
        // Robocop also shoots when he moves
        public void OnMove(float direction)
        {
            Shoot(direction);
        }
    }
    // Hippie robot.
    public class WallE : IRobot
    {
        public float position { get; set; }
        public float speed { get; set; }
        // Wall-E is happy just moving around
        public void OnMove(float direction) { }
    }
