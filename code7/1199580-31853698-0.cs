    public partial class MainWindow : Window
    {
        private DependencyProperty myDP;
        public MainWindow()
        {
            ...
            Binding myBinding = new Binding();
            myBinding.Path = new PropertyPath("myValue"); //myValue is a variable in ViewModel
            myBinding.Source = DataContext;
            myDP = DependencyProperty.Register("myValue", typeof(/*class or primitive type*/), typeof(MainWindow));
            BindingOperations.SetBinding(this, myDP, myBinding);
            ...
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you really want to do that?", "", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes
            {
                SetValue(myDP, /*value*/); //this sets the Binding value. myValue in ViewModel is set
            }
        }
    }
