    public class MyModel{
        public String Name{get;set;}
        public ImageSource Icon {get;set;}
    }
    public static class MyModelContainer{
        private static IEnumerable<MyModel> _myModelList;
        public static IEnumerable<MyModel> MyModelList{get{
            if(_myModelList==null){
                Initialize();
            }
            return _myModelList;
        }}
        private static Initialize(){
            _myModelList = new List<MyModel>() {
                new MyModel(){
                    Name = "Model one"
                    Icon = new BitmapImage(new Uri("ms-appx:///Resources/image1.png"));
                }
            };
        }
    }
