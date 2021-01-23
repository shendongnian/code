	var newlines =
		from line in File.ReadAllLines("source_filename.txt")
		from newline in new []
		{
			line,
			line.Contains("add_zombie_weapon") ? "test 21 " : null
		}
		where newline != null;
		select newline;
		
	File.WriteAllLines("destination_filename.txt", newlines);
