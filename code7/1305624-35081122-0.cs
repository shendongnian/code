    var zone = dnsClient.Zones.CreateOrUpdate("someresourcegroup", "mydomain.com", new Microsoft.Azure.Management.Dns.Models.ZoneCreateOrUpdateParameters {
            IfNoneMatch = "*",
            Zone = new Microsoft.Azure.Management.Dns.Models.Zone {
                Name = "mydomain.com",
                Location = "global"
            }
        });
