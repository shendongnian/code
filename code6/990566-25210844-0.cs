    public class SomeObject {
        public int ID {get;set;}
        public string Name {get;set;}
        public Bitmap Image {get;set;
        public SomeObject(int id, string name, string status) {
            ID = id;
            Name = name;
            Image = status == "Online" ? Resource1.MyOnlineIcon : Resource1.MyOfflineIcon;
        }
    }
