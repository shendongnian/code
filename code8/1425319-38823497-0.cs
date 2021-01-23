    public class MotorController : IMotorController
    {
        private static bool instantiated;
        public MotorController(...)
        {
            if (instantiated)
                throw new InvalidOperationException(
                    "MotorController can only be instantiated once.")
            ...
 
            instantiated = true;
        }
 
        ...
    }
