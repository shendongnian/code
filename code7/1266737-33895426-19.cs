    using System;
    using System.Collections.Generic;
    
    namespace HotelRoomManager
    {
    	class MainClass
    	{
    		public static void Main (string[] args)
    		{
    			RoomManager mgr = new RoomManager (5);
    			for (uint i = 0; i < mgr.Capacity; ++i)
    				mgr.AddRoom (new SingleRoom (1, i + 1) );
    
    			List<IRoom> rooms = mgr.GetAllRooms ();
    			TextView view = new TextView ();
    			view.RenderHeader ();
    			view.RenderModels (rooms);
    
    			mgr.RemoveAllRooms ();
    		}
    	}
    }
