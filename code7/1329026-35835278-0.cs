	string line = "x:2 , y:3 l:6, t:5, n:0 ,genr:plate; x:12 , y:32 l:26, t:45, n:1 ,genr:temp;";
	Dictionary<string,string> linedata = new Dictionary<string,string>();
	string[] lineitems = line.Split(new char[] { ',', ';', ':' }, StringSplitOptions.RemoveEmptyEntries);
	for (int i = 0; i < lineitems.Length; i += 2)
		linedata.Add(lineitems[i], lineitems[i + 1]);
	data.Add(linedata); //each line is one single record in data List
