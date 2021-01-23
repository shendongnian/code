    using System;
    using System.Collections.Generic;
    using System.Text;
    
    namespace HotelRoomManager
    {
    	public class TextView
    	{
    		public TextView () {}
    
    		public void Render(List<IRoom> rooms) {
    			StringBuilder sb = new StringBuilder ();
    			foreach (IRoom r in rooms) {
    				sb.Append ("Floor   : " + r.Floor + "\n");
    				sb.Append ("Number  : " + r.Number + "\n");
    				sb.Append ("Bed     : " + r.BedType + "\n");
    				sb.Append ("Occupied: " + (r.IsOccupied ? "Yes" : "No") + "\n");
    			}
    			Console.WriteLine (sb.ToString ());
    		}
    	}
    }
