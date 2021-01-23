    Dictionary<String, DbRoadNameModel> roadNameModelDictionary;
    using (RoutingDataContext dc = new RoutingDataContext(connectionString))
    {
        roadNames = dc.DbRoadNames
            .Select(roadName => new DbRoadNameModel(roadName.RoadId, roadName.Prop1, roadName.Prop2))
            .ToDictionary(x => x.RoadId);
    }
