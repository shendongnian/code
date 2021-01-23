            var routerDb = RouterDb.Deserialize(...); // load routerdb here.
            var router = new Router(routerDb);
            var routerPoint = router.Resolve(Vehicle.Car.Fastest(), new Coordinate(51.269692005119616f, 4.783473014831543f));
            var edge = routerDb.Network.GetEdge(routerPoint.EdgeId);
            var attributes = routerDb.GetProfileAndMeta(edge.Data.Profile, edge.Data.MetaId);
            var speed = Vehicle.Car.Fastest().Speed(attributes);
