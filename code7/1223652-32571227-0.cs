    abstract class Room
    {
        public virtual int WallCount()
        {
            return 4;
        }
    
        public abstract int WindowsCount();
        public abstract int DoorCount();
    }
    
	class Bedroom : Room
	{
		public override int WindowsCount()
		{
			return 1;
		}
		public override int DoorCount ()
		{
			return 1;
		}
        // ... you get the point I hope
    }
