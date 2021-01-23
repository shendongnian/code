    public class Product {
        // Note that I've added a constructor for this class - this'll help later
        public Product(string productName, string customerName, string firmwareLocation) {
            this.productName = productName;
            this.customerName = customerName;
            this.firmwareLocation = firmwareLocation;
        }
        public void Save (System.IO.TextWriter textOut)
        {
            textOut.WriteLine(String.Format(
                "{0},{1},{2}", this.productName, this.customerName, this.firmwareLocation);
        }
    }
