        interface IConstructionInputs
        {
            DateTime DateLastModified { get; }
        }
        interface IRoofCostInputs : IConstructionInputs
        {
        }
        interface IWallCostInputs : IConstructionInputs
        {
        }
        interface IBuildingCostInputs : IRoofCostInputs, IWallCostInputs
        {
        }
        class BuildingCostInputs : IBuildingCostInputs
        {
            public DateTime DateLastModified { get; private set; }
        }
