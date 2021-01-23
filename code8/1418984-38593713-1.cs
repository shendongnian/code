		public class MarkedArray {
				public MarkedArray(  int size ) {
              		  Busy = false;
              		  Array = new string[size];
				}
				public bool Busy {get;set;}
				public string[] Array  {get;set;}
		}
		
		static List<MarkedArray> result = Etikeketter(arrEtikets, 20);
