    /// <summary>
    /// Represents a Vehicle.
    /// </summary>
    public abstract class Vehicle
    {
        /// <summary>
        /// Prints the Number of Wheels to the Console.
        /// Virtual so can be changed by more derived types.
        /// </summary>
        public virtual void VirtualPrintNumberOfWheels()
        {
            Console.WriteLine("Number of Wheels: 4");
        }
 
        /// <summary>
        /// Prints the Number of Wheels to the Console.
        /// </summary>
        public void ShadowPrintNumberOfWheels()
        {
            Console.WriteLine("Number of Wheels: 4");
        }
    }
 
    /// <summary>
    /// Represents a Motorcycle.
    /// </summary>
    public class Motorcycle : Vehicle
    {
        /// <summary>
        /// Prints the Number of Wheels to the Console.
        /// Overrides base method.
        /// </summary>
        public override void VirtualPrintNumberOfWheels()
        {
            Console.WriteLine("Number of Wheels: 2");
        }
 
        /// <summary>
        /// Prints the Number of Wheels to the Console.
        /// Shadows base method.
        /// </summary>
        public new void ShadowPrintNumberOfWheels()
        {
            Console.WriteLine("Number of Wheels: 2");
        }
    }
