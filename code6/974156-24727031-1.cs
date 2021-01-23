    public FlowDocument YourProperty
    {
        get { return yourProperty; }
        set
        {
            yourProperty = value;
            NotifyPropertyChanged("YourProperty");
            NotifyPropertyChanged("YourEditedProperty");
        }
    }
    public FlowDocument YourEditedProperty
    {
        get { return SomeManipulationMethod(YourProperty); }
    }
...
    <Prefix:BindableRichTextBox Name="TextBox1" Document="{Binding YourProperty}" />
    ...
    <Prefix:BindableRichTextBox Name="TextBox2" Document="{Binding YourEditedProperty}" />
