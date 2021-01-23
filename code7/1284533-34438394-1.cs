	static void Main(string[] args) {
		string fileNamePath = "ConsoleApplication1.pdb";
		var segmentSize = 32;
		var op = ReadSplit(fileNamePath, segmentSize);
		var joinedSTring = string.Join(Environment.NewLine, op);
	}
	static List<string> ReadSplit(string filePath, int segmentSize) {
		var splitOutput = new List<string>();
		using (var file = new StreamReader(filePath)) {
			char []buffer = new char[segmentSize];
			while (!file.EndOfStream) {
				int n = file.ReadBlock(buffer, 0, segmentSize);
				splitOutput.Add(new string(buffer, 0, n));
			}
		}
		return splitOutput;
	}
