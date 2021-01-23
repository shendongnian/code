    var list = new List<RecordSerializable>();
	using (var stream = new FileStream(fileName, FileMode.Open)) {
		while (stream.Position < stream.Length) {
			list.Add((RecordSerializable)formatter.Deserialize(stream));
		}
	}
