    <Button x:Name="OkButton" Style="{DynamicResource OKBtn}" Content="{Binding FooText}" />
    private string fooText;
    public string FooText
    {
       get { return fooText; }
       set
       {
           fooText = value;
           OnPropertyChanged("FooText");
       }
    }
