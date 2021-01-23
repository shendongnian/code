    namespace Test
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            /// <summary>
            /// Store your ListBox entrys here
            /// </summary>
            public ObservableCollection<string> ItemCollection
            {
                get { return (ObservableCollection<string>)GetValue(ItemCollectionProperty); }
                set { SetValue(ItemCollectionProperty, value); }
            }
    
            // Using a DependencyProperty as the backing store for ItemCollection.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty ItemCollectionProperty =
                DependencyProperty.Register("ItemCollection", typeof(ObservableCollection<string>), typeof(MainWindow), new PropertyMetadata(new ObservableCollection<string>()));
    
    
            /// <summary>
            /// This binds to the TextBox text
            /// </summary>
            public string TextBoxText
            {
                get { return (string)GetValue(TextBoxTextProperty); }
                set { SetValue(TextBoxTextProperty, value); }
            }
    
            // Using a DependencyProperty as the backing store for TextBoxText.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty TextBoxTextProperty =
                DependencyProperty.Register("TextBoxText", typeof(string), typeof(MainWindow), new PropertyMetadata(string.Empty, OnTextBoxTextChanged));
    
            private static void OnTextBoxTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
            {
                MainWindow self = d as MainWindow;
    
                if(self != null)
                {
                    self.OnTextBoxTextChanged(args.NewValue.ToString());
                }
            }
    
            private void OnTextBoxTextChanged(string newValue)
            {
                if (this.ItemCollection.Contains(newValue))
                {
                    this.SelectedItem = newValue;
                }
                else
                {
                    this.SelectedItem = null;
                }
            }
    
    
            /// <summary>
            /// This binds to the selected item of your ListBox
            /// </summary>
            public string SelectedItem
            {
                get { return (string)GetValue(SelectedItemProperty); }
                set { SetValue(SelectedItemProperty, value); }
            }
    
            // Using a DependencyProperty as the backing store for SelectedItem.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty SelectedItemProperty =
                DependencyProperty.Register("SelectedItem", typeof(string), typeof(MainWindow), new PropertyMetadata(string.Empty, OnSelectedItemChanged));
    
            private static void OnSelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
            {
                MainWindow self = d as MainWindow;
    
                if (self != null)
                {
                    self.OnSelectedItemChanged(args.NewValue as string);
                }
            }
    
            private void OnSelectedItemChanged(string newValue)
            {
                if (!this.TextBoxText.Equals(newValue) && !string.IsNullOrEmpty(newValue))
                {
                    this.TextBoxText = newValue;
                }
            }
    
    
            public MainWindow()
            {
                InitializeComponent();
                this.ItemCollection.Add("Name 1");
                this.ItemCollection.Add("Name 2");
                this.ItemCollection.Add("Name 3");
                this.ItemCollection.Add("Name 4");
                this.ItemCollection.Add("Name 5");
    
            }
    
        }
    }
