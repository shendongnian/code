	public void ProcessImage()
	{
		int ilength = Input.Length;
		Debug.Assert(ilength == Output.Length);
		Debug.Assert(ilength%4 == 0);
		unsafe
		{
			GCHandle pinned1 = GCHandle.Alloc(Input, GCHandleType.Pinned);
			byte* input = (byte*)pinned1.AddrOfPinnedObject();
			GCHandle pinned2 = GCHandle.Alloc(Input, GCHandleType.Pinned);
			byte* output = (byte*)pinned2.AddrOfPinnedObject();
			for (int i = 0; i < ilength; i += 4)
			{
				var brightness = (*(input) + *(input  + 1) + *(input + 2)) / 3; 
				if (brightness > Threshold)
				{
					// What is the most efficient way possible to do this?
					(*(output)) = (byte)(255 - *(input));
					(*(output+1)) = (byte)(255 - *(input+1));
					(*(output+2)) = (byte)(255 - *(input+2));
				}
				else
				{
					(*(output)) = *(input);
					(*(output + 1)) = *(input + 1);
					(*(output + 2)) = *(input + 2);
				}
				input += 4;
				output += 4;
			}
			pinned1.Free();
			pinned2.Free();
		}
	}
