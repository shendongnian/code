    public class MainPage: Page {
        public MainPage() { 
            Loaded += MainPage_Loaded;
        }
        public void MainPage_Loaded() {
            MyTextBlock.DataContext = new ExcercizeTable();
        }
    }
