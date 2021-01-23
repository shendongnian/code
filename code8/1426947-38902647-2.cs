    public class MyCustomControl : ItemsControl {
    
            static MyCustomControl() {
                DefaultStyleKeyProperty.OverrideMetadata(typeof(MyCustomControl), new FrameworkPropertyMetadata(typeof(MyCustomControl)));
            }
    
            private Button _addButton, _deleteButton;
            private TextBox _textBox;
            private ListView _itemsView;
    
            public override void OnApplyTemplate() {
                this._addButton = this.GetTemplateChild("PART_AddButton") as Button;
                this._deleteButton = this.GetTemplateChild("PART_DeleteButton") as Button;
                this._textBox = this.GetTemplateChild("PART_TextBox") as TextBox;
                this._itemsView = this.GetTemplateChild("PART_ListBox") as ListView;
                this._deleteButton.Click += (sender, args) => {
                    (this.ItemsSource as IList<string>).Remove((string)this._itemsView.SelectedItem);
                };
                this._addButton.Click += (sender, args) => {
                    (this.ItemsSource as IList<string>).Add(this._textBox.Text);
                };
                this._itemsView.ItemsSource = this.ItemsSource;
                base.OnApplyTemplate();
            }
        }
