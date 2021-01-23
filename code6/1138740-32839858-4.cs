        using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    
    namespace CapMachina.Common.Controls
    {
      public partial class FormField_UC : UserControl
      {
    public string Header
    {
      get { return (string)GetValue(HeaderProperty); }
      set { SetValue(HeaderProperty, value); }
    }
    public static readonly DependencyProperty HeaderProperty =
        DependencyProperty.Register("Header", typeof(string), typeof(FormField_UC));
    public string Text
    {
      get { return (string)GetValue(TextProperty); }
      set { SetValue(TextProperty, value); }
    }
    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register("Text", typeof(string), typeof(FormField_UC));
    public string WaterMarkText
    {
      get { return (string)GetValue(WaterMarkTextProperty); }
      set { SetValue(WaterMarkTextProperty, value); }
    }
    public static readonly DependencyProperty WaterMarkTextProperty =
        DependencyProperty.Register("WaterMarkText", typeof(string), typeof(FormField_UC));
    public bool IsReadOnly
    {
      get { return (bool)GetValue(IsReadOnlyProperty); }
      set { SetValue(IsReadOnlyProperty, value); }
    }
    public static readonly DependencyProperty IsReadOnlyProperty =
        DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(FormField_UC), new PropertyMetadata(true));
    public Style ReadOnlyStyle { get; set; }
    public Style DefaultStyle { get; set; }
    public FormField_UC()
    {
      ReadOnlyStyle = Application.Current.FindResource("ReadOnlyTextBox") as Style;
      DefaultStyle = Application.Current.FindResource("DefaultTextBox") as Style;
      InitializeComponent();
    }
    private void MainTxtBx_TextChanged(object sender, TextChangedEventArgs e)
    {
      if (string.IsNullOrEmpty(MainTxtBx.Text) && IsReadOnly)
        Visibility = Visibility.Collapsed;
      else
        Visibility = Visibility.Visible;
    }
    private void MainTxtBx_Loaded(object sender, RoutedEventArgs e)
    {
      BindingExpression mainTxtBxBinding = BindingOperations.GetBindingExpression(MainTxtBx, TextBox.TextProperty);
      BindingExpression textBinding = BindingOperations.GetBindingExpression(this, TextProperty);
      if (textBinding != null && mainTxtBxBinding != null && textBinding.ParentBinding != null && textBinding.ParentBinding.ValidationRules.Count > 0 && mainTxtBxBinding.ParentBinding.ValidationRules.Count < 1)
      {
        foreach (ValidationRule vRule in textBinding.ParentBinding.ValidationRules)
          mainTxtBxBinding.ParentBinding.ValidationRules.Add(vRule);
      }
        }
      }
    }
