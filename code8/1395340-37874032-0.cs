    List<OwnerTransportTransport> ListIWantToShow =
                            (from transport in dbContext.TransportOwner
                            select new OwnerTransportTransport()
                            {
                                ID = transport.ID,
                                TransportID = transport.TransportID,
                                BrandName = transport.Transport.BrandName,
                                ModelName = transport.Transport.ModelName
                            }).ToList();
    public class OwnerTransportTransport
    {
      public int OwnerTransportID { get; set; }
      public int TransportID { get; set; }
      public string Brand { get; set; }
      public string Model { get; set; }
    }
