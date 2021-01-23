    static public class Util {
        static Random rnd = new Random();
        static public int PriorityPickEnum(this Enum e) {
            // The approved types for an enum are byte, sbyte, short, ushort, int, uint, long, or ulong
            // However, Random only supports a int (or double) as a max value.  Either way
            // it doesn't have the range for uint, long and ulong.
            //
            // sum enum 
            int sum = 0;
            foreach (var x in Enum.GetValues(e.GetType())) {
                sum += Convert.ToInt32(x);
                }
            var i = rnd.Next(sum); // get a random value, it will form a ratio i / sum
            // enums may not have a uniform (incremented) value range (think about flags)
            // therefore we have to step through to get to the range we want,
            // this is due to the requirement that return value have a probability
            // proportional to it's value.  Note enum values must be sorted for this to work.
            foreach (var x in Enum.GetValues(e.GetType()).OfType<Enum>().OrderBy(a => a)) {
                i -= Convert.ToInt32(x);
                if (i <= 0) return Convert.ToInt32(x);
                }
            throw new Exception("This doesn't seem right");
            }
        }
