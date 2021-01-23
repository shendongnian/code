    //this is the backing store property
    public static readonly DependencyProperty ListBoxInfoProperty =
           DependencyProperty.Register("ListBoxInfo", typeOf(ObservableCollection<Tbl_my_Info>), typeof(thisControlType));
    //this is the CLR Wrapper
    public ObservableCollection<Tbl_my_Info> ListBoxInfo {
        get{return (ObservableCollection<Tbl_my_Info>)GetValue(ListBoxInfoProperty);}
        set{SetValue(ListBoxInfoProperty,value);}
