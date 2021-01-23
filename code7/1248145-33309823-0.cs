    public static class ID
    {
        // Enumeration for parameter in NewID() method.
        public enum Type { Customer, Vendor, Product, Transaction };
    }
    public class MyClass
    {
        // Variables hold the last ID. This will need to be serialized
        // into your database.
        public int lastCustomerID;
        public int lastVendorID;
        public int lastProductID;
        public int lastTransactionID;
        // Updates last-ID variable and returns its value.
        public int NewID(ID.Type type)
        {
            switch (type)
            {
                case ID.Type.Customer:
                    lastCustomerID++;
                    return lastCustomerID;
                case ID.Type.Vendor:
                    lastVendorID++;
                    return lastVendorID;
                case ID.Type.Product:
                    lastProductID++;
                    return lastProductID;
                case ID.Type.Transaction:
                    lastTransactionID++;
                    return lastTransactionID;
                default:
                    throw new ArgumentException("An invalid type was passed: " + type);
            }
        }
        private void AnyMethod()
        {
            // Generate new customer ID for new customer.
            int newCustomerID = NewID(ID.Type.Customer);
            // Now the ID is in a variable, and your last-ID variable is updated.
            // Be sure to serialize this data into your database, and deserialize
            // it when creating new instances.
        }
    }
