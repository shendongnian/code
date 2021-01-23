    namespace ClassLibrary1
    {
        public class Class1
        {
            public void Generate()
            {
                string remainingDigits = "0123456789";
                System.Random r = new System.Random();
                string output = null;
                int count = 10;
                int index = r.Next(count);
                output += remainingDigits[index];
                remainingDigits = remainingDigits.Remove(index, 1);
                count -= 1;
                index = r.Next(count);
                output += remainingDigits[index];
                remainingDigits = remainingDigits.Remove(index, 1);
                count -= 1;
                index = r.Next(count);
                output += remainingDigits[index];
                remainingDigits = remainingDigits.Remove(index, 1);
                count -= 1;
                index = r.Next(count);
                output += remainingDigits[index];
            }
        }
    }
