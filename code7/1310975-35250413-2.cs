    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Runtime.Serialization.Json;
    using System.IO;
    
    namespace SerializationTests {
        [TestClass]
        public class JsonDeserializationTests {
            [TestMethod]
            public void Deserialize_Delete_Type_Success() {
                string json = string.Empty;
                //Set the DataContractJsonSerializer target type to our wrapper type.
                var ser = new DataContractJsonSerializer(typeof(DeleteWrapperJsonResult));
                //Create an instance of the wrapper that reflects the JSON  that you gave.
                //This will help me mock the data that you gave.
                var deleteWrapper = new DeleteWrapperJsonResult {
                    delete = new DeleteJsonResult {
                        status = new DeletedStatusJsonResult {
                            id = 696142765093072896,
                            user_id = 2223183576
                        }
                    }
                };
                //Convert the mock data to JSON to reflect the JSON that you gave.
                using (var serStream = new MemoryStream()) {
                    using (var sr = new StreamReader(serStream)) {
                        ser.WriteObject(serStream, deleteWrapper);
                        serStream.Position = 0;
                        json = sr.ReadToEnd(); //Set the JSON string here.
                        //Output "{\"delete\":{\"status\":{\"id\":696142765093072896,\"id_str\":\"696142765093072896\",\"user_id\":2223183576,\"user_id_str\":\"2223183576\"}}}"
                    }
                }
                //Prepeare to Deserialize the JSON.
                var deserialized = default(DeleteWrapperJsonResult);
                using (var deserStream = new MemoryStream()) {
                    using (var sw = new StreamWriter(deserStream)) {
                        sw.Write(json); //Write the JSON to the MemoryStream
                        sw.Flush();
                        deserStream.Seek(0, SeekOrigin.Begin);
                        //Deserialize the JSON into an instance of our wrapper class.
                        //This works because of the structure of the JSON.
                        deserialized = (DeleteWrapperJsonResult)ser.ReadObject(deserStream);
                    }
                }
                //Initialize the actual Delete instanace with what was deserialized.
                var delete = new Delete {
                    Status = new DeletedStatus {
                        //These values were populated with the JSON values.
                        UserId = deserialized.delete.status.user_id,
                        Id = deserialized.delete.status.id
                    }
                };
                //Write asserts around what was given and check for equality.
                Assert.AreEqual(delete.Status.UserId, deleteWrapper.delete.status.user_id);
                Assert.AreEqual(delete.Status.Id, deleteWrapper.delete.status.id);
                //Test Passes for Me
            }
        }
    }
