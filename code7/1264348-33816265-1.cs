    public class Program
    {
        public static void Main(string[] args)
        {
            PrintHourGlass(25);
        }
        /// <summary>
        /// Prints an hour glass starting at the given offset
        /// </summary>
        /// <param name="indent">The starting offset</param>
        static void PrintHourGlass(int indent)
        {
            PrintAsteriks(indent, 5); // offset = indent, print 5 *          [I]*****
            PrintAsteriks(indent + 1, 3); // offset = indent + 1, print 3 *  [I] ***
            PrintAsteriks(indent + 2, 1); // offset = indent +3, print 1 *   [I]  *
            PrintAsteriks(indent + 1, 3); // offset = indent + 1, print 3 *  [I] ***
            PrintAsteriks(indent, 5); // offset = indent, print 5 *          [I]*****
        }
        /// <summary>
        /// Prints given number of * characters starting from the given offset
        /// </summary>
        /// <param name="indent">The starting offset</param>
        /// <param name="asterisks">The number of * characters to print</param>
        static void PrintAsteriks(int indent, int asterisks)
        {
            // Check starters guide to string.Format here:
            // https://msdn.microsoft.com/en-us/library/system.string.format(v=vs.110).aspx#Starting
            // string format uses a template and allows you to pass in and format arguments as you like.
            // The template below evaluates to {0,25}{1} for indent = 25 and asteriks = 5
            // which means,
            // print argument 0 (first parameter), no extra formatting, pad the output to 25 characters
            // print argument 1, no formatting
            string formatString = "{0," + indent + "}{1}";
            // Console.WriteLine method uses string.Format internally
            // Below, for the template, argument 0 is null
            //     (since we want to print only 25 characters, the padding.
            //     The value could have been "" instead of null)
            // Argument 1 is a string of * characters, with the length specified by asteriks parameter
            Console.WriteLine(formatString, null, new string('*', asterisks));
            // Therefore, it outputs 25 linear white spaces, then 5 * characters.
        }
    }
