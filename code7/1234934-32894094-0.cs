    var listOfCustomerSearchResult = (from customer in entities.Customers
            where customer.Number.StartsWith(customerNumber)
            select new { CustomerSearchResult = new CustomerSearchResult
            {
                AccountNbr = (customer.Number.IndexOf(".") > 0) ? customer.Number.Substring(0, customer.Number.IndexOf(".")) : customer.Number,
                SubAccountNbr = (customer.Number.IndexOf(".") > 0) ? customer.Number.Substring(customer.Number.IndexOf(".") + 1) : string.Empty,
                FirstAndLastName = (customer.Contact.IsIndividual) ? (customer.Contact.FirstNameCareOf + " " ?? string.Empty) + (customer.Contact.Name ?? string.Empty) : (customer.Contact.Name ?? string.Empty) + " " + (customer.Contact.FirstNameCareOf ?? string.Empty),
                StreetAddress = customer.Contact.Addresses.FirstOrDefault().StreetAddress ?? string.Empty,
                City = customer.Contact.Addresses.FirstOrDefault().City ?? string.Empty,
                ZipCode = customer.Contact.Addresses.FirstOrDefault().ZipCode ?? string.Empty,
                Region = customer.Contact.Addresses.FirstOrDefault().Region.Code ?? string.Empty,
                Delivery = string.Empty,
                IsActive = customer.IsActive,
                IsAdministrative = customer.IsAdministrative,
                SearchStep = 1,
                CustomerId = customer.Id,
                AccountType = customer.Type.EnumId,
                Phone = customer.Contact.Phones.FirstOrDefault().Number ?? string.Empty
    
            }, FormatedPhone = FormatPhone(customer.Phone), ... ).Take(500).ToList();
