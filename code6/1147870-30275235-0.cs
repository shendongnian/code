       class Program
    {
        static void Main(string[] args)
        {
            int maxItems = 6;
            int maxValue = 99232;
            //currently this is disregarded because there can be less than 6 items.
            int minValue = 10;
            //the list to store string formmated items
            List<string> finalList = new List<string>();
            int divider = (GetBestValue(maxValue, maxItems));
            finalList.Add(string.Format("less then {0}", divider));
            int currentAmmount = divider;
            while (currentAmmount < maxValue)
            {
                if (currentAmmount + divider > maxValue)
                    finalList.Add(string.Format("{0} and above", currentAmmount + 1));
                else
                    finalList.Add(string.Format("rs. {0} - rs. {1}", currentAmmount + 1, currentAmmount + divider));
                currentAmmount += divider;
            }
            foreach (var item in finalList)
            {
                Console.WriteLine(item);
            }
        }
        /// <summary>
        /// This method will seek the best divider to take 
        /// </summary>
        /// <param name="max">Max value to use</param>
        /// <param name="maxItems"></param>
        /// <param name="minValue"></param>
        /// <returns></returns>
        static int GetBestValue(int max, int maxItems) 
        {
            int startingValue = 1;
            int startingMaxValue = max;
            while (startingMaxValue/10 > 0)
            {
                startingValue *= 10;
                startingMaxValue /= 10;
            }
            while (max / startingValue > maxItems) 
            {
                startingValue *= 2;
            }
            return startingValue;
        }
    }
