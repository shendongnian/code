    int i = 0;
    foreach (DataRow hadr in tblRepeatService.Rows)
    { 
         _hotelamenties = new HotelAmenties();
         _hotelamenties.Id = Guid.NewGuid();
         _hotelamenties.ServiceName = hadr["Service"].ToString();
         _hotelamenties.HotelCode = hadr["HotelCode"].ToString();
         db.HotelAmenties.Add(_hotelamenties);
         if((i%1000)==0){
         db.SaveChanges();
         }
         i++;
    }    
    db.SaveChanges();
