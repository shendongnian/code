     var qry = (from client in AgencyContext.Client
                join estate in AgencyContext.Estate on client.ClientID equals estate.ClientID
                select new 
                {
                    ClientId = estate.ClientId,
                    ClientName = client.ClientName
                });
