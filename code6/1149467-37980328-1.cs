    public class Example
    {
        void Start()
        {
            WallE wallE = new WallE();
            Robocop robocop = new Robocop();
            
            // Calling Move() (from IRobotHelper)
            // First it will execute the shared functionality, as specified in IRobotHelper
            // Then it will execute any implementation-specific functionality,
            // depending on which class called it. In this case, WallE's OnMove().
            wallE.Move(1);
            // Now if we call the same Move function on a different implementation of IRobot
            // It will again begin by executing the shared functionality, as specified in IRobotHlper's Move function
            // And then it will proceed to executing Robocop's OnMove(), for Robocop-specific functionality.
            robocop.Move(1);
            // The whole concept is similar to inheritence, but for interfaces.
            // This structure offers an - admittedly dirty - way of having some of the benefits of a multiple inheritence scheme in C#, using interfaces.
        }
    }
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
