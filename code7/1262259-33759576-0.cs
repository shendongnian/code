    var query = from client in db.Clients
                from policy in client.Policies_Property
                where policy.CovertTo >= ConvertToStart && policy.ConverTo <= ConverToEnd
                select new
                {
                    client.Client_Details_Legacy.FullName, 
		            client.Client_Details_Legacy.AddressLine1, 
		            client.Client_Details_Legacy.AddressLine2, 
		            client.Client_Details_Legacy.AddressLine3, 
		            policy.PolicyNumber, 
		            policy.CoverTo, 
		            client.Id
                };
