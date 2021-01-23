    public static void Main(string[] args)
        {
            var finalString = string.Empty;
            var stringNotMade = true;
            var random = new Random();
            while (stringNotMade)
            {
                var finalArray = new string[9];
                for (var i = 0; i < 3; i++)
                {
                    var alphabet = random.Next(0, 26);
                    var letter = (char)('a' + alphabet);
                    finalArray[i] = letter.ToString().ToUpper();
                }
                for (var i = 3; i < 9; i++)
                {
                    var number = random.Next(0, 9);
                    finalArray[i] = number.ToString();
                }
                var shuffleArray = finalArray.OrderBy(x => random.Next()).ToArray();
                for (var i = 0; i < finalArray.Length; i++)
                {
                    finalString += shuffleArray[i];
                }
                stringNotMade = false;
            }
            Console.WriteLine(finalString);
            Console.ReadKey();    
        }
