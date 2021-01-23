    public partial class HyperVControl : UserControl, INotifyPropertyChanged
    {
       private Boolean _IsVisible;
       
       public Boolean IsVisible
       {
           get
           {
               return this._IsVisible;
           }
           set
           {
              if (value == this._IsVisible)
                 return;
    
              this._IsVisible = value;
              this.OnPropertyChanged("IsVisible")
           }
       }
       ...
    }
    
    <CheckBox Tag="ElementName" Content="{StaticResource MenMachinename}" IsChecked="{Binding Data.IsVisible, Source={StaticResource proxy}, UpdateSourceTrigger=PropertyChanged, Mode=OneWayToSource}"/>
    ...
    
    <DataGridTextColumn Header="{StaticResource MenMachinename}" Binding="{Binding ElementName}" Visibility="{Binding Data.IsVisible, UpdateSourceTrigger=PropertyChanged, Source={StaticResource proxy}, Converter={StaticResource BoolToVisibilityConv},  Mode=OneWay}" />
