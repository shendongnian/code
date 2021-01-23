          <telerik:GridViewDataColumn x:Name="GRIDVIEWCOLUMN_ENDDATE" Header="Data de Conclusão" DataMemberBinding="{Binding ClosedDate, StringFormat=dd-MM-yyyy}" IsVisible="False" Width="auto" IsFilterable="False">
                <telerik:GridViewDataColumn.ToolTipTemplate>
                    <DataTemplate>
                     <Border Background="Black" Visibility="{Binding ClosedDate, Converter={StaticResource BorderVisible}}" >
                        <TextBlock Text="{Binding ClosedDate, StringFormat=dd-MM-yyyy}" FontFamily="Segoe UI Light" FontSize="13.667" />
                     </Border>
                    </DataTemplate>
                </telerik:GridViewDataColumn.ToolTipTemplate>
            </telerik:GridViewDataColumn>
    
        class BorderVisibilitySetter : IValueConverter
        {
        
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
               //check if the control's content property is null or empty        
                if(value == null || value.ToString() == string.Empty)
                    return Visibility.Collapsed;
                else
                    return Visibility.Visible;
            }
        
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
