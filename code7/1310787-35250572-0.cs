    private static RSAParameters Create(byte[] p, byte[] q, byte[] exponent, byte[] modulus)
    {
        var addlParameters = GetFullPrivateParameters(
            p: new BigInteger(CopyAndReverse(p)),
            q: new BigInteger(CopyAndReverse(q)),
            e: new BigInteger(CopyAndReverse(exponent)),
            modulus: new BigInteger(CopyAndReverse(modulus)));
        return new RSAParameters
        {
            P = p,
            Q = q,
            Exponent = exponent,
            Modulus = modulus,
            D = addlParameters.D,
            DP = addlParameters.DP,
            DQ = addlParameters.DQ,
            InverseQ = addlParameters.InverseQ,
        };
    }
    private static RSAParameters GetFullPrivateParameters(BigInteger p, BigInteger q, BigInteger e, BigInteger modulus)
    {
        var n = p * q;
        var phiOfN = n - p - q + 1; // OR: (p - 1) * (q - 1);
        var d = ModInverse(e, phiOfN);
        Assert.Equal(1, (d * e) % phiOfN);
        var dp = d % (p - 1);
        var dq = d % (q - 1);
        var qInv = ModInverse(q, p);
        //Assert.Equal(1, (qInv * q) % p);
        return new RSAParameters
        {
            D = CopyAndReverse(d.ToByteArray()),
            DP = CopyAndReverse(dp.ToByteArray()),
            DQ = CopyAndReverse(dq.ToByteArray()),
            InverseQ = CopyAndReverse(qInv.ToByteArray()),
        };
    }
    /// <summary>
    /// Calculates the modular multiplicative inverse of <paramref name="a"/> modulo <paramref name="m"/>
    /// using the extended Euclidean algorithm.
    /// </summary>
    /// <remarks>
    /// This implementation comes from the pseudocode defining the inverse(a, n) function at
    /// https://en.wikipedia.org/wiki/Extended_Euclidean_algorithm
    /// </remarks>
    public static BigInteger ModInverse(BigInteger a, BigInteger n)
    {
        BigInteger t = 0, nt = 1, r = n, nr = a;
        if (n < 0)
        {
            n = -n;
        }
        if (a < 0)
        {
            a = n - (-a % n);
        }
        while (nr != 0)
        {
            var quot = r / nr;
            var tmp = nt; nt = t - quot * nt; t = tmp;
            tmp = nr; nr = r - quot * nr; r = tmp;
        }
        if (r > 1) throw new ArgumentException(nameof(a) + " is not convertible.");
        if (t < 0) t = t + n;
        return t;
    }
    private static byte[] CopyAndReverse(byte[] data)
    {
        byte[] reversed = new byte[data.Length];
        Array.Copy(data, 0, reversed, 0, data.Length);
        Array.Reverse(reversed);
        return reversed;
    }
