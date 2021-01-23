    public class MyModel {
    
        // This property contains the available options
        public SelectList AllOptions { get; set; }
    
        // This property contains the selected options
        public IEnumerable<string> SelectedOptions { get; set; }
    
        public MyModel() {
            AllOptions = new SelectList(
                new[] { "Option1", "Option2", "Option3" });
    
            SelectedOptions = new[] { "Option1" };
        }
    }
