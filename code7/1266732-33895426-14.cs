    using System;
    
    namespace HotelRoomManager
    {
    	public sealed class SingleRoom : Room
    	{
    		public SingleRoom (uint floor, uint number) : base(floor, number)
    		{}
    
    		override public BedType BedType {
    			get { return BedType.Single; }
    		}
    	}
    }
