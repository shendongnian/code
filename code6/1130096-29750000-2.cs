    XNamespace ns = "http://www.testing.com";
    List<Hotel> result = xdoc.Descendants(ns + "Hotel")
                      .Select(x => new Hotel
                           {
                              HotelCode = (string)x.Attribute("HotelCode"),
                              HotelName = (string)x.Attribute("HotelName"),
                              RoomTypes = x.Descendants(ns + "RoomType")
                                         .Select(r => new RoomType
                               {
                                       RoomTypeCode = (string)r.Attribute("RoomTypeCode"),
                                       RoomTypeName = (string)r.Attribute("RoomTypeName")
                               }).ToList(),
                             AvailabilityGroup = x.Descendants(ns + "AvailabilityGroup")
                                                 .Select(a => new availability_group
                     {
                        AvailabilityGroupCode = (string)a.Attribute("AvailabilityGroupCode"),
                        AvailabilityGroupName = (string)a.Attribute("AvailabilityGroupName") 
                     }).ToList()
             }).ToList();
