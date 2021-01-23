        static void Normalize(double[] numbers)
        {
            double max = numbers.Max();
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = numbers[i] / max;
            }
        }
