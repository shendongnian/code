    public class AddressesManager
    {
        public Addresses GetAddress(short id)
        {
            using(var entityContext = new SiteDBEntities())
            {
                var address = entityContext.Addresses
                                           .Where(a => a.Id == id)
                                           .ProjectTo<AddressDTO>()
                                           .FirstOrDefault();
                return address;
            }
        }
    }
 
