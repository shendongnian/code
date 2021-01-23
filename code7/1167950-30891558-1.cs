    public Street AddStreet(string streetName)
    {
        Street street = new Street();
        street.StreetName = streetName;
        using (var _db = new DataContext())
        {
            // Dodaj Street u bazu [AD_STREET]
            _db.DB_Street.Add(street);
            _db.SaveChanges();
        }
        // Success.
        return street;
    }
