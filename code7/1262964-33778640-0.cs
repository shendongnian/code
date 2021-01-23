    var TopNode = new SearchHierarchyModel();
    
    var groundList = new List<SearchHierarchyModel>();
    foreach (var gr in ground)
    {
        SearchHierarchyModel newGround = new SearchHierarchyModel()
        {
            Name = gr.ground,
            Type = "GRD",
            RowID = gr.Id.ToString()
        };
        groundList.Add(newGround);
        var buildingList = new List<SearchHierarchyModel>();
        foreach (var by in building)
        {
            SearchHierarchyModel newBuilding = new SearchHierarchyModel()
            {
                Name = by.building,
                Type = "BUI",
                RowID = by.Id.ToString()
            };
            buildingList.Add(newBuilding);
            foreach (var fl in floors)
            {
                if (by.Id == fl.Bygning_Bygning_id)
                {
                    var floorList = new List<SearchHierarchyModel>();
                    floorList.Add(new SearchHierarchyModel
                    {
                        Name = fl.floor,
                        Type = "FLR",
                        RowID = fl.Id.ToString()
                    });
                    newBuilding.Children = floorList;
                }
            }
            newGround.Children = buildingList;
        }
        TopNode.Children = groundList;
    }
