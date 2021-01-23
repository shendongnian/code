    var lines = File.ReadAllLines(filePath);
    var products = new List<Product>();
    foreach (string line in lines) {
        if (Regex.IsMatch(line, @"super awesome regex")) {
            string[] lineItems = line.Split(','); // Splits line at commas into array
            products.Add(new Product(line[0], line[1], line[2]); // Thanks to our constructor
        }
    }
    foreach (var product in products) {
        Console.WriteLine(String.Format("Product name: {0}", product.productName));
    }
