    public class CriteriaView : ItemsControl {
    
        public static readonly DependencyProperty AddCommandProperty = DependencyProperty.Register(
                "AddCommand",
                typeof(ICommand),
                typeof(CriteriaView),
                new PropertyMetadata(default(ICommand)));
    
        public ICommand AddCommand {
          get {
            return (ICommand)GetValue(AddCommandProperty);
          }
          set {
            SetValue(AddCommandProperty, value);
          }
        }
    
        public static readonly DependencyProperty RemoveCommandProperty = DependencyProperty.Register(
            "RemoveCommand",
            typeof(ICommand),
            typeof(CriteriaView),
            new PropertyMetadata(default(ICommand)));
    
        public ICommand RemoveCommand {
          get {
            return (ICommand)GetValue(RemoveCommandProperty);
          }
          set {
            SetValue(RemoveCommandProperty, value);
          }
        }
    
        private TextBox _box;
    
        public override void OnApplyTemplate() {
          this._box = this.GetTemplateChild("TextBlock") as TextBox;
          this._box.PreviewKeyDown += this.UIElement_OnPreviewKeyDown;
          base.OnApplyTemplate();
        }
    
        private void UIElement_OnPreviewKeyDown(object sender, KeyEventArgs e) {
          if (this.AddCommand != null && (e.Key == Key.Enter || e.Key == Key.Return || e.Key == Key.Tab))
            this.AddCommand.Execute(this._box.Text);
    
        }
    
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e) {
          if (RemoveCommand == null)
            return;
          var no = (sender as FrameworkElement)?.DataContext as int?;
          RemoveCommand.Execute(no);
        }
    
      }
