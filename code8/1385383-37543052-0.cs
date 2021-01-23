    Console.WriteLine("Path.AltDirectorySeparatorChar={0}", Path.AltDirectorySeparatorChar);
	Console.WriteLine("Path.DirectorySeparatorChar={0}", Path.DirectorySeparatorChar);
	Console.WriteLine("Path.PathSeparator={0}", Path.PathSeparator);
	Console.WriteLine("Path.VolumeSeparatorChar={0}", Path.VolumeSeparatorChar);
	Console.Write("Path.GetInvalidPathChars()=");
	foreach (char c in Path.GetInvalidPathChars())
	    Console.Write(c);
	Console.WriteLine();
