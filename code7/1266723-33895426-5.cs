    using System;
    
    namespace HotelRoomManager
    {
    	public enum Bed
    	{
    		Single,
    		Double,
    		Twin,
    		Queen,
    		King
    	}
    
    	public interface IRoom
    	{
    		Bed Bed { get; }
    		uint Floor { get; }
    		uint Number { get; }
    		bool IsOccupied { get; set; }
    	}
    }
