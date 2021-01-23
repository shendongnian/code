    var mySTr = "My § sign";
    var encoded = System.Text.Encoding.UTF8.GetBytes(mySTr);
    var encoding2 = Convert.ToBase64String(encoded);
    Console.WriteLine("Base64 encoded: " + encoding2);
    var decoded = Convert.FromBase64String(encoding2);
    var decodedStr = System.Text.Encoding.UTF8.GetString(decoded);
    Console.WriteLine("Decoded again: " + decodedStr);
    Debug.Assert(mySTr.Equals(decodedStr, StringComparison.Ordinal));
