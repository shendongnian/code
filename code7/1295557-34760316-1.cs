    class Program
    {
        static void Main(string[] args)
        {
            //different sizes for each row.
            byte[,] arrays = new byte[2,40];
            arrays[0,0] = (byte)'A';
            arrays[0, 1] = (byte)'B';
            arrays[0, 2] = (byte)'C';
            arrays[0, 3] = (byte)'D';
            arrays[1, 0] = (byte)'E';
            arrays[1, 1] = (byte)'F';
            arrays[1, 2] = (byte)'G';
            arrays[1, 3] = (byte)'H';
            arrays[1, 4] = (byte)'I';
            List<string> stringArray = new List<string>();
            List<byte> stringBytes = new List<byte>();
            for (int row = 0; row < arrays.GetLength(0); row += 1)
            {
                for (int col = 0; col < arrays.GetLength(1); col += 1)
                {
                    //got a null terminator
                    if (arrays[row, col] == 0)
                    {
                        //check if it's for UTF8 encoding.
                        if (arrays.GetLength(1) == col+1 || arrays[row,col+1] == 0)
                        {
                            //nope. End of this string.
                            stringArray.Add(Encoding.UTF8.GetString(stringBytes.ToArray()));
                            stringBytes.Clear();
                            break;
                        }
                    }
                    // add all bytes for the current row.
                    stringBytes.Add(arrays[row, col]);
                }
            }
            foreach (var item in stringArray)
            {
                //prints:
                // ABCD
                // EFGHI
                Console.WriteLine(item);
            }
        }
    }
