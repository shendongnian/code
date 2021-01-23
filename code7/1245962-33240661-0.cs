    public static readonly DependencyProperty Text1Property =
    DependencyProperty.Register("Text1", typeof(string), 
        typeof(BasicControl), new PropertyMetadata(text1Changed));
    //the text1Changed callback
    static void text1Changed(DependencyObject o, DependencyPropertyChangedEventArgs e){
         var bc = o as BasicControl;
         if(bc != null) bc.OnPropertyChanged("Text2");
    }
