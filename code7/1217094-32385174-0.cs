	public class TileData{
		public bool IsWalkable{get;};
		public bool IsBuildSpace{get;};
		public Zone ZoneType{get;};
		public int TileGraphicIndex{get;};
		public static TileData FLOOR    = new TileData(true, true, Zone.None, 1);
		public static TileData WALL     = new TileData(false, false, Zone.None, 0);
		public static TileData FARMLAND = new TileData(true, false, Zone.Arable, 2);
		//...etc
		public TileData(bool walkable, bool buildSpace, Zone zone, int grahpicIndex){
			IsWalkable = walkable;
			IsBuildSpace = buildSpace;
			ZoneType = zone;
			TileGraphicIndex = grahpicIndex;
		}
		
		public TileData(){
			IsWalkable = true;
			IsBuildSpace = false;
			ZoneType = Zone.None;
			TileGraphicIndex = 0;
		}
		public enum Zone{
			Shipping,
			Receiving,
			Arable,
			None
		}
	}
