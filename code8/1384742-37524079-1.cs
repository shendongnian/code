    public class Time
    {
        public static implicit operator Time(string value)
        {
            // Initialize your object with value
            // Similar to 
            var values = value.Split(':');
            var hour = Convert.ToInt32(values[0]);
            var min = Convert.ToInt32(values[1]);
            . . .
        }
        . . .   // Your fields, properties and methods
    }
