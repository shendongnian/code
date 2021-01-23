      public class ClassToCheckSerialization
      {
         public string StringProperty { get; set; }
         [JsonConverter(typeof(MemoryStreamJsonConverter))]
         public Stream StreamProperty { get; set; }
      }
      private void CheckJsonSerializationOfClass()
      {
         var data = new ClassToCheckSerialization();
         var ms = new MemoryStream();
         const string entryString = "Test string inside stream";
         var sw = new StreamWriter(ms);
         sw.WriteLine(entryString);
         sw.Flush();
         ms.Position = 0;
         data.StreamProperty = ms;
         var json = JsonConvert.SerializeObject(data);
         var result = JsonConvert.DeserializeObject<ClassToCheckSerialization>(json);
         var sr = new StreamReader(result.StreamProperty);
         var stringRead = sr.ReadLine();
         //Assert.AreEqual(entryString, stringRead);
      }
