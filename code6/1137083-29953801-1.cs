        public static int[] MakePi(int n)
        {
            
            var pi = Math.PI;
            var piString = pi.ToString().Remove(1, 1);
            var newPi = new int[n];
            for (var i = 0; i < newPi.Count() ; i++)
            {
                int.TryParse(piString.Substring(i, 1), out newPi[i]);
                Console.WriteLine(newPi[i]);
            }
            return newPi;
        }
