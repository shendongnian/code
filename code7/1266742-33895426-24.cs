    using System;
    using System.Collections.Generic;
    using System.Text;
    
    namespace HotelRoomManager
    {
    	public class TextView
    	{
    		public TextView () {}
    
    		public void RenderHeader() {
    			Console.WriteLine ("Hotel Management System");
    			Console.WriteLine ("-----------------------");
    		}
    
    		public void RenderModels(List<IRoom> rooms) {
    			StringBuilder sb = new StringBuilder ();
    			foreach (IRoom r in rooms) {
    				sb.Append ("Floor   : " + r.Floor + "\n");
    				sb.Append ("Number  : " + r.Number + "\n");
    				sb.Append ("Bed     : " + r.BedType + "\n");
    				sb.Append ("Occupied: " + (r.IsOccupied ? "Yes" : "No") + "\n\n");
    			}
    			Console.WriteLine (sb.ToString ());
    		}
    	}
    }
