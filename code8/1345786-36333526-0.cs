     static void Main(string[] args)
        {
            string input = "3c8080080040040020020010010000000000000000003c";
            bool[][] daySchedule = ParseSchedule(input);
        }
        static bool[] DayScheduleFromBits(int bits) => Enumerable.Range(0, 12).Select(h => ((1 << (11 - h)) & bits) != 0).ToArray();
        static bool[][] ParseSchedule(string input)
        {
            input = input.Substring(2, input.Length - 4);
            var chunks = Enumerable.Range(0, input.Length / 3).Select(i => input.Substring(i * 3, 3));
            return chunks.Select(chunk => DayScheduleFromBits(Convert.ToInt32(chunk, 16))).ToArray();
        }
