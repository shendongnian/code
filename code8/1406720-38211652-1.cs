    var buildingData  = context.Buildings
                               .Select(b => new
                                {
                                    b.Id,
                                    b.Name,
                                    RoomNumbers = b.Rooms
                                                   .Select(r => r.Number)
                                });
    var buildingViews = buildingData.AsEnumerable()
                                    .Select(b => new BuildinView
                                     {
                                         Id = b.Id,
                                         Name = b.Name,
                                         RoomNumbers = string.Join(", ", b.Rooms)
                                     });
