    public abstract class Tile
    {
        public Tile()
        {
            // Default attributes of a Tile
            IsWalkable = false;
            IsBuildSpace = false;
            ZoneType = Zone.None;
            GraphicIndex = -1;
        }
        public virtual bool IsWalkable { get; private set; }
        public virtual bool IsBuildSpace { get; private set; }
        public virtual Zone ZoneType { get; private set; }
        public virtual int GraphicIndex { get; private set; }
    
        /// <summary>
        /// Factory to build the derived types objects
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Get<T>() where T : Tile, new()
        {
            return new T();
        }
    }
