	using Collections = System.Collections.Generic;
		public static int IndexOf<T>( this Collections.IReadOnlyList<T> self, T elementToFind )
		{
			int i = 0;
			foreach( T element in self )
			{
				if( Equals( element, elementToFind ) )
					return i;
				i++;
			}
			return -1;
		}
