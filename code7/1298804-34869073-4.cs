        var Location = (from su in db.Suburbs.AsEnumerable()
                                 where su.postcode.Contains(pcode) &&
                                 su.name.Contains(SuburbName)
                                 join sur in db.SubRegions on
                                 su.SubRegionID equals sur.SubregionID
                                 join re in db.AuRegions on
                                 sur.RegionID equals re.RegionID
                                 join DT in db.DeliveryPeriods on
                                 sur.DeliveryTimeId equals DT.Id
                                 join dts in Days on
                                 su.SubRegionID equals dts.SubRegionID 
                                 select new Posts
                                 {
                                     suburb = new Suburb()
                                     {
                                         name = su.name,
                                         postcode = su.postcode,
                                       
                                     },
                                     region = new Region()
                                     {
                                         Name = re.Name
                                     },
                                     deliveryTime = new DeliveryTime()
                                     {
                                         DeliveryDay = DT.DeliveryDay,
                                         DeliveryType = DT.DeliveryType,
                                     },
                                     subRegion = new SubRegion()
                                     {
                                         CloseDayId = sur.CloseDayId,
                                         SubregionName = sur.SubregionName,
                                         SubregionID = sur.SubregionID
                                     },
                                     deliveryDays = new DeliveryDays() 
                                     {
                                       
                                        Firstweek = dts.Firstweekdate ,
                                        cutDayFirst = dts.cutDayFirstdate,
                                     },
                                   }).ToList();
                return Location1.Select(l => new LocationDTO
                {
                    DeliveryDay = l.deliveryTime.DeliveryDay,
                    PostCode = l.suburb.postcode,
                    CloseDayId = l.subRegion.CloseDayId,
                    SubregionID = l.subRegion.SubregionID,
                    TFirstDeliveryDay = l.deliveryDays.Firstweek.ToString("dddd, d MMMM yyyy"),
                    TFirstCutOffDay = l.deliveryDays.cutDayFirst.ToString("dddd, d MMMM yyyy"),
          
                }).ToList();
