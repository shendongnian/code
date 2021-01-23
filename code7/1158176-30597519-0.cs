    public class MyModel
    {
        public int selectedValue {get;set;}
        public string data {get;set;}
        public MyModel() {
            // MyModel.selectedValue will always be 5 unless specified otherwise
            this.selectedValue = 5;
        }
    }
