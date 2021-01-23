    [Flags]
    public enum BiomeType
    {
        Warm = 1,
        Hot = 2,
        Cold = 4,
        Intermediate = 8,
        Dry = 16,
        Moist = 32,
        Wet = 64,
    }
    BiomeType bType = BiomeType.Hot  | BiomeType.Dry;
