    /// <summary>
    /// Normalizes the values within this array.
    /// </summary>
    /// <param name="data">The array which holds the values to be normalized.</param>
    static void Normalize(this float[] data)
    {
        float max = float.MinValue;
        // Find maximum
        for (int i = 0; i < data.Length; i++)
        {
            if (Math.Abs(data[i]) > max)
            {
                max = data[i];
            }
        }
        // Divide all by max
        for (int i = 0; i < data.Length; i++)
        {
            data[i] = data[i] / max;
        }
    }
