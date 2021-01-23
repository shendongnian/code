    private static readonly Random random = new Random((int)DateTime.UtcNow.Ticks);
    private static int GetRandomPermutation(int input)
    {
        char[] chars = input.ToString().ToCharArray();
        for (int i = 0; i < chars.Length; i++ )
        {
            int j = random.Next(chars.Length);
            if (j != i)
            {
                char temp = chars[i];
                chars[i] = chars[j];
                chars[j] = temp;
            }
        }
        return int.Parse(new string(chars));
    }
