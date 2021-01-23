    public partial class ShirazRailwayEntities : DbContext
    {
        public ShirazRailwayEntities()
            : base(name: "ShirazRailwayEntities")
        {
        }
        public ShirazRailwayEntities(string connectionName)
            : base(name: connectionName)
        {
        }
    }
    var context = new ShirazRailwayEntities("whatever connection name you want");
