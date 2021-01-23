        public static List<string> IpListToCIDR(List<string> ipList)
        {
            //Suanda sadece C blok icin yazilmistir. Ileride gelistirilebilir
            //result list
            List<string> compressedList = new List<string>();
            
            //group ip addresses
            var cidrList = ipList.GroupBy(o => new
                                {
                                   GrpKey = o.Substring(0, o.LastIndexOf('.'))
                                })
                                .Select(g => new
                                {
                                    IpSubnet = g.Key.GrpKey,
                                    Count = g.Count()
                                })
                                .Where(m => m.Count >= 255)
                                .ToList();
            //exclude grouped list
            var excludeList = (from a in ipList
                               join c in cidrList on a.Substring(0, a.LastIndexOf('.')) equals c.IpSubnet
                               select a).ToList();
            //add C block CIDR list
            compressedList.AddRange(cidrList.Select(m => m.IpSubnet + ".0/24").ToList());
            //add rest of them
            compressedList.AddRange(ipList.Where(m=> !excludeList.Contains(m)).ToList());
            return compressedList;
        }
