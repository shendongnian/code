    using System;
    
    namespace HotelRoomManager
    {
    	public enum BedType
    	{
    		Single,
    		Double,
    		Twin,
    		Queen,
    		King
    	}
    
    	public interface IRoom
    	{
    		BedType BedType { get; }
    		uint Floor { get; }
    		uint Number { get; }
    		bool IsOccupied { get; set; }
    	}
    }
