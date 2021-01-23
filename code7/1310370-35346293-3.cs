    byte[] bytes = System.Convert.FromBase64String (s);
	float[] f = ConvertByteToFloat(bytes);
    // Normalize the values before using them
    f.Normalize();
    
	AudioClip audioClip = AudioClip.Create("testSound", f.Length, 2, 44100, false, false);
	audioClip.SetData(f, 0);
