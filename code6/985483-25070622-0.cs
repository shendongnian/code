    static void Main()
        {
          string base64a = "ODk3NTU5NS8zOS84OTc1NTk1XzM5XzE3MjNfMjI4MjAubXAz";
          string base64b = "ODk3NTU5NS8zOS84OTc1NTk1XzM5XzE3MjNfMjI4MjAub2dn";
          Console.WriteLine(Encoding.Default.GetString(Convert.FromBase64String(base64a)));
          Console.WriteLine(Encoding.Default.GetString(Convert.FromBase64String(base64b)));
          Console.ReadKey();
        }
