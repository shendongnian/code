    using System;
    using System.Drawing;
    namespace Demo
    {
        internal class Program
        {
            private void run()
            {
                // As an example, iterate through all known colours and demonstrate
                // that we can convert each colour to a 5 character string and back.
                var colors = Enum.GetValues(typeof(KnownColor));
                foreach (KnownColor knowColor in colors)
                {
                    Color colour = Color.FromKnownColor(knowColor);
                    string colourString = ColourToBase52(colour);
                    Color decodedColour = ColourFromBase52(colourString);
                    if (colour.ToArgb() != decodedColour.ToArgb())
                        Console.WriteLine("ERROR with colour " + colour); // Expect this to complain about TRANSPARENT.
                    else
                        Console.WriteLine("{0,-30} is represented by {1}", colour, colourString);
                }
            }
 
            public static string ColourToBase52(Color colour)
            {
                int value = colour.ToArgb() & 0x00FFFFFF; // Mask off the alpha channel.
                return ToBase52(value);
            }
            public static Color ColourFromBase52(string colour)
            {
                int value = FromBase52(colour);
                return Color.FromArgb(unchecked((int)(0xFF000000 | value)));
            }
            public static string ToBase52(int value)
            {
                char[] baseChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
                int targetBase = baseChars.Length;
                int i = 32;
                char[] buffer = new char[i];
                do
                {
                    buffer[--i] = baseChars[value % targetBase];
                    value = value / targetBase;
                }
                while (value > 0);
                char[] result = new char[32 - i];
                Array.Copy(buffer, i, result, 0, 32 - i);
                return new string(result);
            }
            public static int FromBase52(string value)
            {
                char[] baseChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
                int targetbase = baseChars.Length;
            
                int multiplier = 1;
                int result = 0;
                for (int i = value.Length-1; i >= 0; --i)
                {
                    int digit = Array.IndexOf(baseChars, value[i]);
                    result += digit*multiplier;
                    multiplier *= targetbase;
                }
                return result;
            }
            public static void Main()
            {
                new Program().run();
            }
        }
    }
