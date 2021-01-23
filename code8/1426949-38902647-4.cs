    public class MyCustomControl : ItemsControl {
    
            static MyCustomControl() {
                DefaultStyleKeyProperty.OverrideMetadata(typeof(MyCustomControl), new FrameworkPropertyMetadata(typeof(MyCustomControl)));
            }
    
            private Button _addButton;
            private TextBox _textBox;
            private ListView _itemsView;
    
            public override void OnApplyTemplate() {
                this._addButton = this.GetTemplateChild("PART_AddButton") as Button;
                this._textBox = this.GetTemplateChild("PART_TextBox") as TextBox;
                this._itemsView = this.GetTemplateChild("PART_ListBox") as ListView;
    
                this._addButton.Click += (sender, args) => {
                    (this.ItemsSource as IList<string>).Add(this._textBox.Text);
                };
                this._itemsView.ItemsSource = this.ItemsSource;
                base.OnApplyTemplate();
            }
    
            public ICommand DeleteCommand => new RelayCommand(x => { (this.ItemsSource as IList<string>).Remove((string)x); });
        }
