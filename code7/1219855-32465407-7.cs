		public static int OffsetToStringData
		{
			// This offset is baked in by string indexer intrinsic, so there is no harm
			// in getting it baked in here as well.
			[System.Runtime.Versioning.NonVersionable] 
			get {
				// Number of bytes from the address pointed to by a reference to
				// a String to the first 16-bit character in the String.  Skip 
				// over the MethodTable pointer, & String 
				// length.  Of course, the String reference points to the memory 
				// after the sync block, so don't count that.  
				// This property allows C#'s fixed statement to work on Strings.
				// On 64 bit platforms, this should be 12 (8+4) and on 32 bit 8 (4+4).
		#if WIN32
				return 8;
		#else
				return 12;
		#endif // WIN32
			}
		}
	 
	   Except...
	   
