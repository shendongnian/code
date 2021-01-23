    class Tile
    {
        public TCODColor color { get; protected set; }
        public int glyph { get; protected set; }
    
        public virtual bool isDigable() 
        { 
            return false; 
        }
        public virtual bool isGround() 
        { 
            return false; 
        }
    }
    class Wall: Tile
    {
        public override bool isDigable()
        { 
            return true; 
        }
    }
    class Floor : Tile
    {
        public override bool isGround()
        { 
            return true; 
        }
    }
