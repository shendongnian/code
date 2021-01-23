    public class FloorMap
    {
        public int FloorMapID { get; set; }
        public int FloorNumber { get; set; }
        public string FloorImage { get; set; }
        public string FloorMapDescription { get; set; }
        public virtual List<MapObject> MapObjects { get; set; }
        public virtual MapObject MapObject { get; set; }
    }
    
    public partial class MapObject
    {
        [Key,ForeignKey ("FloorMap")]
        public int FloorMapRefID { get; set; }
        public virtual FloorMap FloorMap { get; set; }
        public int OtherFloorMapRefID {get;set;}
        public virtual FloorMap OtherFloorMap { get; set; }
    }
    modelBuilder.Entity<FloorMap>().HasMany(e => e.MapObjects).WithRequired(e=>e.OtherFloorMap).HasForeignKey(e=>e.OtherFloorMapRefID);
    modelBuilder.Entity<FloorMap>().HasOptional(e => e.MapObject).WithRequired(e=>e.FloorMap);
