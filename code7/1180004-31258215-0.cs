    string yol =  "isimler.txt";
	System.IO.StreamWriter zzz = new System.IO.StreamWriter(yol);
	string[] lines = Directory.GetDirectories(@"C:\");
	foreach(string name in lines)
		zzz.WriteLine(name);
	zzz.Close();
