    using System;
    public class DoStuff
    {
        public static void ShowVariable()
        {
            var type = typeof(Program);
            var field = type.GetField("myString", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
            var val = field.GetValue(null); //as the field doesn't belong to an instance
            Console.WriteLine(val);
        }
    }
