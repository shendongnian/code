    class KeyValuePair {
       int Id {get; set;}
       string name {get; set;}
       string stringValue {get; set;}
    }
    class BaseObject {
        int Id {get; set;}
        list<KeyValuePair> dynamicProperties {get; set;}
    }
