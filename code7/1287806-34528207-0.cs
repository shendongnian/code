    public class SourceCustomerRepository
      {
    
        public CustomerInfo GetCustomer(String CustomerName, String CustomerSurName, String CustomerAddress, String CustomerEmail, String CustomerPhone,
            String Barcode, String StoreName, String City, String Town, String BirthDay, String CreateDate, String Signature,
            String IsProcessed, String CreateDateHour, String IsChecked, String IsEmpty)
        {
          return from result in dc.CustomerInfos
          where result.CustomerName == CustomerName
          select result;
        }
    
      }
