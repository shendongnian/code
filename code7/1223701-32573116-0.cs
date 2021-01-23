    public class LongLat {
		private float mLongitude;
		private float mLatitude;
		public float Longitude {get; set; }
		public float Latitude {get; set; }
	}
	
	public class LongLatSort : IComparer {
		public int IComparer.Compare(object a, object b) {
			LongLat o1=(LongLat)a;
			LongLat o2=(LongLat)b;
			if (o1.Longitude > o2.Longitude) {
				return -1; // flipped for descending
			} else if ( o1.Latitude < o2.Longitude ) {
				return 1;  // flipped for descending
			}
			// secondary sort on latitude when values are equal
			return o1.Latitude > o2.Latitude ? -1 : 1; // flipped for descending
		}
	}
	
