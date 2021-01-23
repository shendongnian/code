    public class MainWindow : Window
    {
        A objA = new A(){ Name = "AAA", Age = 19 };
    
        private void SomeMethod()
        {
            var thing = objA.Name;
        }
    }
