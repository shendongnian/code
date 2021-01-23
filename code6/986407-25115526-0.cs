    [TestMethod]
     public void List_Test()
     {
        var resource = new Resource() { ResourceProperty = "Resource" };
        var video = new Video() { ResourceProperty = "Video", VideoProperty = "VideoMP4" };
     
       var list = new List<Resource>() { resource, video };
     
       // Again the important part are the settings
       var settings = new JsonSerializerSettings()
       {
          TypeNameHandling = TypeNameHandling.Objects
       };
     
       var serializedList = JsonConvert.SerializeObject(list, settings);
     
       var deserializedList = JsonConvert.DeserializeObject<List<Resource>> (serializedList, settings);
     
       // And we recover the information with NO data loss
       Assert.AreEqual("Resource", deserializedList[0].ResourceProperty);
       Assert.AreEqual("VideoMP4", ((Video)deserializedList[1]).VideoProperty);
    }
