	static int Main(string[] args)
	{
		var mapName = args[0];
		using (var mapFile = MemoryMappedFile.OpenExisting(mapName))
		{
			string typeAqn;
			string methodName;
			byte[] target;
			using (var stream = mapFile.CreateViewStream())
			using (var br = new BinaryReader(stream))
			{
				typeAqn = br.ReadString();
				methodName = br.ReadString();
				target = br.ReadBytes(br.ReadInt32());
			}
			var type = Type.GetType(typeAqn);
			if (type == null) return -10;
			var method = type.GetMethod(methodName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.InvokeMethod);
			if (method == null) return -11;
			if (method.GetParameters().Length > 0) return -12;
			object returnValue;
			if (target.Length == 0)
			{
				if (!method.IsStatic) return -13;
				returnValue = method.Invoke(null, new object[0]);
			}
			else
			{
				object targetInstance;
				using (var ms = new MemoryStream(target)) targetInstance = new BinaryFormatter().Deserialize(ms);
				returnValue = method.Invoke(targetInstance, new object[0]);
			}
			using (var stream = mapFile.CreateViewStream())
				new BinaryFormatter().Serialize(stream, returnValue);
			return 0;
		}
	}
