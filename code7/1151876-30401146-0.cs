    var task = Task.Factory.FromAsync(
        contactGroupServices.BeginDeleteContact(contactToRemove.Uri),
        ar =>
        {
            try
            {
                _contactGroupServices.EndDeleteContact(ar);
            }
            catch (RealTimeException rtex)
            {
                Console.WriteLine(rtex);
            }
        });
