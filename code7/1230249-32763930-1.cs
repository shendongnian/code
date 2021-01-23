    public class HashGenerator : IHashGenerator
    {
      public string GenerateHash(string input, String salt)
      {
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input + salt);
        SHA256Managed sha256hashstring = new SHA256Managed();
        byte[] hash = sha256hashstring.ComputeHash(bytes);
        return Convert.ToBase64String(bytes);
      }
      public string CreateSalt(int size)
      {
        var rng = new RandomNumberGenerator();
        var buff = new byte[size];
        rng.GetBytes(buff);
        return Convert.ToBase64String(buff);
      }
    }
