    using System;
    public class DoStuff
    {
        public static void ShowVariable()
        {
            var type = typeof(Program); //get type of Program
            //get the field, which is static and private
            var field = type.GetField("myString", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
            var val = field.GetValue(null); //field value, null - as the field doesn't belong to an instance
            Console.WriteLine(val);
        }
    }
