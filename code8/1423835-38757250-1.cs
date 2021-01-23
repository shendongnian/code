    string MyBoolName = "IsEnabled";
    string MyTextName = "Title";
    string xaml =
     @"<DataTemplate
    xmlns:local=""clr-namespace:Templating;assembly=Templating""
    x:Key=""goDropColumn"">
                    <ComboBox Name=""combo"" Width=""85"" ItemsSource=""{Binding Path=DataContext.MyThings,
            RelativeSource={RelativeSource AncestorType={x:Type DataGrid}}}""
                              SelectedValue=""{Binding "+ MyBoolName + @"}""
           >
    <ComboBox.Resources>
    <local:BrushColorConverter x:Key=""goColorConverter""></local:BrushColorConverter>
    </ComboBox.Resources>
    
                        <!-- SelectedValue=""{Binding ???}"" -->
                        <ComboBox.ItemTemplate>
                            <DataTemplate>
                                <StackPanel Orientation=""Horizontal"">
                                    <Ellipse Fill=""{Binding IsEnabled,  Converter={StaticResource goColorConverter}}""
                               Height=""14"" Width=""14"" />
                                    <TextBlock Text=""{Binding " + MyTextName + @"}"" Padding=""5 0""/>
                                </StackPanel>
                            </DataTemplate>
                        </ComboBox.ItemTemplate>
                    </ComboBox>
                </DataTemplate>";
