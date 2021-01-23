    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    
    namespace SomeNamespace {
      [TestClass]
      public class NullParseJsonTest {
        [TestMethod]
        public void TestMethod1()
        {
          string slice = "{Key:{guid:\"asdf\"}}";
          var result = JsonConvert.DeserializeObject<Root>(slice);
    
          Assert.IsTrue(result.OptionalKey.IsSet);
          Assert.IsNotNull(result.OptionalKey.Value);
          Assert.AreEqual("asdf", result.OptionalKey.Value.Guid);
        }
    
        [TestMethod]
        public void TestMethod2()
        {
          string slice = "{Key:null}";
          var result = JsonConvert.DeserializeObject<Root>(slice);
    
          Assert.IsTrue(result.OptionalKey.IsSet);
          Assert.IsNull(result.OptionalKey.Value);
        }
    
        [TestMethod]
        public void TestMethod3()
        {
          string slice = "{}";
          var result = JsonConvert.DeserializeObject<Root>(slice);
    
          Assert.IsFalse(result.OptionalKey.IsSet);
          Assert.IsNull(result.OptionalKey.Value);
        }
      }
    
      class Root {
    
        public Key Key {
          get {
            return OptionalKey.Value;
          }
          set {
            OptionalKey.Value = value;
            OptionalKey.IsSet = true;   // This does the trick, it is never called by JSON.NET if attribute missing
          }
        }
    
        [JsonIgnore]
        public Optional<Key> OptionalKey = new Optional<Key> { IsSet = false };
      };
    
    
      class Key {
        public string Guid { get; set; }
      }
    
      class Optional<T> {
        public T Value { get; set; }
        public bool IsSet { get; set; }
      }
    }
