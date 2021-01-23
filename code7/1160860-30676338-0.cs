    public class AObject {
        // --->      <--- Changed 
        public object RawJson { get; set; }
        // --->^^^^^^<---
        public decimal Rating { get; set; }
        public BObject BObject { get; set; }
    }
    public class BObject {
        public string Id { get; set; }
    }
    ...
    AObject test = new AObject();
    test.RawJson = JsonConvert.DeserializeObject(remoteJsonResult);
