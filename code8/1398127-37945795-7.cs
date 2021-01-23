    var rd = new Pony { Id = 1, Name = "Rainbow Dash" };
          var fs = new Pony { Id = 2, Name = "Fluttershy", BFF = rd };
          rd.BFF = fs;
          var ponies = new List<Pony> { rd, fs };
    
          object returnValue;
          using (var memoryStream = new MemoryStream()) {
            var binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(memoryStream, ponies);
            memoryStream.Position = 0;
            returnValue = binaryFormatter.Deserialize(memoryStream);
          }
          var xx = (List<Pony>)returnValue;
