	// Implementing this interface introduces the concept of neighbouring buckets.
	public interface IHasNeighbourConcept
	{
		int[] GetSeveralHashCodes();
        // The returned int[] must at least contain the return value of GetHashCode.
	}
	// Custom HashSet-like class that can search in several buckets.
	public class NeighbourSearchHashSet<T> where T : IHasNeighbourConcept
	{
		// Internal data storage.
		private Dictionary<int, List<T>> buckets;
        // Constructor.
		public NeighbourSearchHashSet()
		{
			buckets = new Dictionary<int, List<T>>();
		}
			
		// Classic implementation utilizing GetHashCode.
		public bool Add(T elem)
		{
			int hash = elem.GetHashCode();
			if(!buckets.ContainsKey(hash))
			{
				buckets[hash] = new List<T>();
				buckets[hash].Add(elem);
				return true;
			}
			foreach(T t in buckets[hash])
			{
				if(elem.Equals(t))
					return false;
			}
			buckets[hash].Add(elem);
			return true;
		}
		/// Nonclassic implementation utilizing GetSeveralHashCodes.
		public bool Contains(T elem)
		{
			int[] hashes = elem.GetSeveralHashCodes();
			foreach(int h in hashes)
				foreach(T t in buckets[h])
					if(elem.Equals(t))
						return true;
			return false;
		}
	}
	public class Vector : IHasNeighbourConcept
	{
		private double[] coords;
		private static double TOL = 1E-10;
        // Tolerance for considering two doubles as equal
		public Vector(double x, double y, double z)
		{
			if(double.IsNaN(x) || double.IsInfinity(x) ||
			   double.IsNaN(y) || double.IsInfinity(y) ||
			   double.IsNaN(z) || double.IsInfinity(z))
				throw new NotFiniteNumberException("All input must be finite!");
			coords = new double[] { x, y, z };
		}
		// Two vectors are equal iff the distance of each
        // corresponding component pair is significantly small.
		public override bool Equals(object obj)
		{
			if(!(obj is Vector))
				throw new ArgumentException("Input argument is not a Vector!");
			Vector other = obj as Vector;
			bool retval = true;
			for(int i = 0; i < 2; i++)
				retval = retval && (Math.Abs(coords[i] - other.coords[i]) < TOL);
			return retval;
		}
		// The set of all Vectors with the same HashCode
        // is a cube with side length TOL.
		public override int GetHashCode()
		{
			int x =(int) Math.Truncate(coords[0] / TOL);
			int y =(int) Math.Truncate(coords[1] / TOL);
			int z =(int) Math.Truncate(coords[2] / TOL);
			return x + 3*y + 5*z; // The purpose of the factors is to make
                                  // permuting the coordinates result
                                  // in different HashCodes.
		}
		// Gets the HashCode of the given Vector as well as the 26
        // HashCodes of the surrounding cubes.
		public int[] GetSeveralHashCodes()
		{
			int[] hashes = new int[27];
			int x =(int) Math.Truncate(coords[0] / TOL);
			int y =(int) Math.Truncate(coords[1] / TOL);
			int z =(int) Math.Truncate(coords[2] / TOL);
			for(int i = -1; i <= 1; i++)
				for(int j = -1; j <= 1; j++)
					for(int k = -1; k <= 1; k++)
						hashes[(i+1)+3*(j+1)+9*(k+1)] = (x+i) + 3*(y+j) + 5*(z+k);
			return hashes;
		}
	}
