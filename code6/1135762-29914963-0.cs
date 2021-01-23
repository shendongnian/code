    public static IEnumerable<string> GetProducts(String path, Func<String, bool> lambda)
    {
        using (StreamReader sr = new StreamReader(path))
        {
            string[] products = sr.ReadToEnd().Split(' ');
            // need to get all the products starting with ART
            foreach (string s in products.Where(lambda))
            {
                yield return s;
            }
        }
    }
