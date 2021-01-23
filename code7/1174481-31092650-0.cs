    client.Map<LocationArray>(m => m
                            .MapFromAttributes().Properties(p=>p
                                .NestedObject<Location>(no => no
                                .Name(pl => pl.Locations.First())
                                .Dynamic()
                                .Enabled()
                                .IncludeInAll()
                                .IncludeInParent()
                                .IncludeInRoot()
                                .MapFromAttributes()
                                .Path("full")
                                .Properties(pprops => pprops
                                    .GeoPoint(ps => ps
                                        .Name(pg => pg.Coordinate)
                                        .IndexGeoHash().IndexLatLon()
                                    )
                                )
                            ))
                        );
