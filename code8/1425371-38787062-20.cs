    public enum ProductProperty {
        ProductName,
        CustomerName,
        FirmwareLocation
    }
    List<Product> GetAllProductsFromFile(string filePath) {
        if (!File.Exists(filePath)) throw FileNotFoundException("Couldn't find " + filePath);
        return File.ReadLines(filePath)
           .Select(line => new Product(line.Split(',')[0], line.Split(',')[1], line.Split(',')[2])
            .ToList();
    }
    function SearchProductsByProperty(IEnumerable<Product> products, ProductProperty productProperty, string value) {
        return products.ToList().Where(product => 
            (productProperty == ProductProperty.ProductName) ? product.productName == productName :
            (productProperty == ProductProperty.CustomerName) ? product.customerName == customerName :
            (productProperty == ProductProperty.FirmwareName) ? product.firmwareName == firmwareName : throw new NotImplementedException("ProductProperty must be ProductProperty.ProductName, ProductProperty.CustomerName or ProductProperty.FirmwareName");
        );
    }
