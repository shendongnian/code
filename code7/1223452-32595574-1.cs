    // Two sample donuts
    DbGeometry donut1 = DbGeometry.FromText("POLYGON((0 0, 3 0, 3 3, 0 3, 0 0),(1 1, 2 1, 2 2, 1 2, 1 1))", 0);
    DbGeometry donut2 = DbGeometry.FromText("POLYGON((10 10, 13 10, 13 13, 10 13, 10 10),(11 11, 12 11, 12 12, 11 12, 11 11))", 0);
    // A merged, double-donut
    DbGeometry doubleDonut = donut1.Union(donut2);
    // Produces POLYGON((0 0, 3 0, 3 3, 0 3, 0 0))
    DbGeometry donut1_simple = GetSimpleDbGeography(donut1);
    // Produces MULTIPOLYGON(((10 10, 13 10, 13 13, 10 13, 10 10)),((0 0, 3 0, 3 3, 0 3, 0 0)))
    DbGeometry doubleDonut_simple = GetSimpleDbGeography(doubleDonut);
