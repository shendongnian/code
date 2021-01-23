    public class TextBoxExtensions
    {
    	public static readonly DependencyProperty EditStringFormatProperty = DependencyProperty.RegisterAttached(
    		"EditStringFormat", typeof (string), typeof (TextBoxExtensions),
    		new PropertyMetadata(default(string), OnEditStringFormatChanged));
    
    	private static readonly DependencyProperty OriginalBindingExpressionProperty = DependencyProperty
    		.RegisterAttached(
    			"OriginalBindingExpression", typeof (BindingExpression), typeof (TextBoxExtensions),
    			new PropertyMetadata(default(BindingExpression)));
    
    	private static void OnEditStringFormatChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    	{
    		TextBox textBox = d as TextBox;
    		if (textBox == null)
    			return;
    
    		if (e.NewValue != null && e.OldValue == null)
    		{
    			textBox.IsKeyboardFocusedChanged += TextBoxOnIsKeyboardFocusedChanged;
    		}
    		else if (e.OldValue != null && e.NewValue == null)
    		{
    			textBox.IsKeyboardFocusedChanged -= TextBoxOnIsKeyboardFocusedChanged;
    		}
    	}
    
    	private static void TextBoxOnIsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
    	{
    		TextBox textBox = sender as TextBox;
    
    		if (textBox == null)
    			return;
    
    		if (GetOriginalBindingExpression(textBox) == null)
    		{
    			SetOriginalBindingExpression(textBox, textBox.GetBindingExpression(TextBox.TextProperty));
    		}
    
    		BindingExpression bindingExpression = GetOriginalBindingExpression(textBox);
    
    		if (textBox.IsKeyboardFocused)
    		{
    			Binding parentBinding = bindingExpression.ParentBinding;
    			Binding newBinding = new Binding(parentBinding.Path.Path)
    			{
    				ElementName = parentBinding.ElementName,
    				Path = parentBinding.Path,
    				Mode = parentBinding.Mode,
    				UpdateSourceTrigger = parentBinding.UpdateSourceTrigger,
    				StringFormat = "H:m:s"
    			};
    			foreach (ValidationRule validationRule in parentBinding.ValidationRules)
    			{
    				newBinding.ValidationRules.Add(validationRule);
    			}
    			textBox.SetBinding(TextBox.TextProperty, newBinding);
    		}
    		else
    		{
    			textBox.SetBinding(TextBox.TextProperty, bindingExpression.ParentBinding);
    		}
    	}
    	
    	public static void SetEditStringFormat(DependencyObject element, string value)
    	{
    		element.SetValue(EditStringFormatProperty, value);
    	}
    
    	public static string GetEditStringFormat(DependencyObject element)
    	{
    		return (string) element.GetValue(EditStringFormatProperty);
    	}
    
    	private static void SetOriginalBindingExpression(DependencyObject element, BindingExpression value)
    	{
    		element.SetValue(OriginalBindingExpressionProperty, value);
    	}
    
    	private static BindingExpression GetOriginalBindingExpression(DependencyObject element)
    	{
    		return (BindingExpression) element.GetValue(OriginalBindingExpressionProperty);
    	}
    }
