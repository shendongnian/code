    protected override async void HandleUnauthorizedRequest(AuthorizationContext context)
            {
                var ipAddress = HttpContext.Current.Request.UserHostAddress;
                if (await IpAddressValid(ipAddress)) return;
                var urlHelper = new UrlHelper(context.RequestContext);
                var address = urlHelper.Action("InvalidIpRange", "Account");
                context.Result = new RedirectResult(address ?? "www.google.com");
            }
    
            private async Task<bool> IpAddressValid(string ipAddress)
            {
                if (ipAddress == "::1")
                    return true;
                var longIp = Ip2Int(ipAddress);
                var addr = await GeoIPCountry.ReturnGeoIpCountries(longIp, longIp); //dbContext.GeoIPCountries.Where(x => x.Start >= longIp && x.End <= longIp);
                return addr.All(g => g.CountryCode == "US");
            }
    
            /// <summary>
            /// Converts IP Address to Long Stack Space.
            /// </summary>
            /// <param name="ipAddress"></param>
            /// <returns></returns>
            public int Ip2Int(string ipAddress)
            {
                try
                {
                    var addr = IPAddress.Parse(ipAddress);
                    uint ip =
                        (uint) IPAddress.NetworkToHostOrder((int) BitConverter.ToUInt32(addr.GetAddressBytes(), 0));
                    return (int)ip;
                }
                catch (Exception)
                {
                    return 0;
                }
            }
