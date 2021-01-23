    public static readonly DependencyProperty NumbersSelectorProperty =
    DependencyProperty.Register("NumbersSelector", typeof(NumberList.Numbers), typeof(ControlClass), new UIPropertyMetadata(NumberList.Numbers.One));
    
    public NumberList.Numbers NumbersSelector
    {
        get { return (NumberList.Numbers)GetValue(NumbersSelectorProperty ); }
        set { SetValue(NumbersSelectorProperty , value); }
    }
