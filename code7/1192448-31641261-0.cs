    var orderData = File.ReadAllLines(txtOrders.Text)
        .Skip(1)
        .Select(x => x.Split(','))
        .Select(x =>
        {
            // do your check here, and return null
            if (clientData.FirstOrDefault(c => c.ClientTempId == x[1]).Id == string.Empty)
                return null;
    
            // otherwise return the normal Order object
            return new Order()
            {
                OrderTempId = x[0],
                ClientId = x[1],
                Name = x[3],
                AccountId = accountId
            };
        })
        // then filter out null values
        .Where(x => x != null);
