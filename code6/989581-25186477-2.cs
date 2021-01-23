    // #1 we add the whole routes. One for listing, other for getting
    // a single entity (ticket)
    configuration.Routes.MapHttpRoute(
        name: "Company.AzurePack.Ticketing.List",
        routeTemplate: "api/company/tickets",
        defaults: new
        {
            controller = "Ticketing",
            action = "GetTickets"
        }
    );
    configuration.Routes.MapHttpRoute(
        name: "Company.AzurePack.Ticketing.GetOne",
        routeTemplate: "api/company/tickets/{id}",
        defaults: new 
        { 
            controller = "Ticketing", 
            action = "GetTicket" 
        }
    );
    // #2 we get both added routes from the route table and we create two
    // references to them. Later, we remove and re-insert them at the top
    // of route table. BINGO!
    RouteBase apiRoute1 = RouteTable.Routes[RouteTable.Routes.Count - 1];
    RouteBase apiRoute2 = RouteTable.Routes[RouteTable.Routes.Count - 2];
    RouteTable.Routes.Remove(apiRoute1);
    RouteTable.Routes.Remove(apiRoute2);
    RouteTable.Routes.Insert(0, apiRoute1);
    RouteTable.Routes.Insert(0, apiRoute2);
