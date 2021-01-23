	public virtual void WriteLine(String value) {
 
		if (value==null) {
			WriteLine();
		}
		else {
			// We'd ideally like WriteLine to be atomic, in that one call
			// to WriteLine equals one call to the OS (ie, so writing to 
			// console while simultaneously calling printf will guarantee we
			// write out a string and new line chars, without any interference).
			// Additionally, we need to call ToCharArray on Strings anyways,
			// so allocating a char[] here isn't any worse than what we were
			// doing anyways.  We do reduce the number of calls to the 
			// backing store this way, potentially.
			int vLen = value.Length;
			int nlLen = CoreNewLine.Length;
			char[] chars = new char[vLen+nlLen];
			value.CopyTo(0, chars, 0, vLen);
			// CoreNewLine will almost always be 2 chars, and possibly 1.
			if (nlLen == 2) {
				chars[vLen] = CoreNewLine[0];
				chars[vLen+1] = CoreNewLine[1];
			}
			else if (nlLen == 1)
				chars[vLen] = CoreNewLine[0];
			else
				Buffer.InternalBlockCopy(CoreNewLine, 0, chars, vLen * 2, nlLen * 2);
			Write(chars, 0, vLen + nlLen);
		}
		/*
		Write(value);  // We could call Write(String) on StreamWriter...
		WriteLine();
		*/
	}
	
