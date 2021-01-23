    var  Location1 = (from su in db.TLCSuburb
                                    join Subr in db.TLCSubRegion on
                                    su.SubRegionID equals Subr.SubregionID
                                    join srdt in db.TLCSubRegionDeliveryTime on
                                    Subr.SubregionID equals srdt.SubregionID
                                    join DT in db.TLCDeliveryTime on
                                    srdt.DeliveryTimeId equals     DT.DeliveryTimeId
                                    join DP in db.TLCDeliveryPeriod on
                                    DT.DeliveryPeriodID equals DP.DeliveryPeriodID
                                    orderby Subr.SubregionID
                                    select new Post
                                    {
                                        suburb = new Suburb(){
                                           Name = su.name,
                                           PostCode = su.postcode,
                                           AuState = su.AuState,
                                           Latitude = su.Latitude,
                                           Longitude = su.Longitude
                                         }, 
                                        deliveryTime = DT.DeliveryDay,
                                        deliveryPeriod = new DeliveryPeriod(){
                                            PeriodType = DP.PeriodType
                                         },
                                        subRegion = new SubRegion(){ 
                                            CloseDayId = Subr.CloseDayId,
                                            SubRegionName = Subr.SubregionName
                                         }
                                    }).ToList();
