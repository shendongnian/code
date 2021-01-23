    var combinedDataList = (from d1 in dataList1 
                               //join d2 in dataList2 on d1.Home equals d2.Home
                               join d2 in dataList2 on new { d1.Home, d1.Away } equals new { d2.Home, d2.Away }
    
                               select new CombinedData
                               {
                                   Campionato = d1.Campionato,
                                   Data = d1.Data,
                                   Home = d2.Home,
                                   Away = d2.Away,
                                   HSFT = d1.HSFT,
                                   ASFT = d1.ASFT,
                                   HSHT = d1.HSHT,
                                   ASHT = d1.ASHT,
                                   HSSH = d1.HSSH,
                                   ASSH = d1.ASSH,
                                   HODD = d2.HODD,
                                   XODD = d2.XODD,
                                   AODD = d2.AODD,
                                   RisFin = d2.RisFin,
                                   Over05SH = d2.Over05SH
    
                               }).OrderBy(p=>p.HODD); 
