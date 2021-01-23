    public class Floor : Tile
    {
        public override bool IsBuildSpace
        {
            get { return true; }
        }
        public override bool IsWalkable
        {
            get { return true; }
        }
        public override int GraphicIndex
        {
            get { return 1; }
        }
    }
    public class Wall : Tile
    {
        public override int GraphicIndex
        {
            get {  return 0; }
        }
        public override Zone ZoneType
        {
            get { return Zone.Arable; }
        }
    }
