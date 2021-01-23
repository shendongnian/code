    var inputs = new List<string>();
    var result = new ConcurrentBag<string>();
    // Create inputs from the input string.
    for (int i = 0; i < iterations; ++i)
    {
        inputs.Add(inputString.Substring(base64BlockSize * i, base64BlockSize));
    }
            
    Parallel.For(0, iterations, i =>
    {
        var encryptedBytes = Convert.FromBase64String(inputs[i]);
        result.Add(rsaCryptoServiceProvider.Decrypt(encryptedBytes, true));
    });
