    // Generate Fingerprint
    ulong fingerprint = 0;
    for (int i = 0; i < HashSize; i++)
    {
        if (vector[i] > 0)
        {
            fingerprint += 1UL << i;
        }
    }
