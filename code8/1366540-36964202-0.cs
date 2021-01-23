        public class MaskedTextBox : TextBox
    {
        public static readonly DependencyProperty DocumentTextProperty =
             DependencyProperty.Register("DocumentText", typeof(string),
             typeof(MaskedTextBox), new PropertyMetadata(default(string), TextChangedCallback));
        private static void TextChangedCallback(DependencyObject
        dependencyObject, DependencyPropertyChangedEventArgs
        dependencyPropertyChangedEventArgs)
        {
            var control = (MaskedTextBox)dependencyObject;
            control.Text= dependencyPropertyChangedEventArgs.NewValue.ToString();
        }
        public string DocumentText
        {
            get { return (string)GetValue(DocumentTextProperty); }
            set { SetValue(DocumentTextProperty, value); }
        }
    }
    <StackPanel Margin="50,5,5,50">
            <local:MaskedTextBox x:Name="text1" DocumentText="{Binding ElementName=text2, Path=Text, Mode=OneWay}"/>
            <TextBox x:Name="text2"/>
        </StackPanel>
