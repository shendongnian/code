    public class MyRootObject {
        public string type {get;set;}
        public string version {get;set;}
        public Dictionary<string, Item> data {get;set;}
    }
    pulic class Item {
        public int id {get;set;}
        public string key {get;set;}
        public string name {get;set;}
        public string title {get;set;}
        public Dictionary<string,int> info {get;set;}
    }
