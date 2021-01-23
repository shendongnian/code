    <UserControl.Resources>
        <ResourceDictionary>
            <local:PercentageConverter x:Key="PercentageConverter"></local:PercentageConverter>
        </ResourceDictionary>
    </UserControl.Resources>
    <Grid Name="ParentGrid">
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="Auto"></ColumnDefinition>
            <ColumnDefinition Width="Auto" ></ColumnDefinition>
        </Grid.ColumnDefinitions>
        <ScrollViewer Grid.Column="0" 
                HorizontalScrollBarVisibility="Auto" 
                MinWidth="200" 
                Width="{Binding Path=ActualWidth, ElementName=ParentGrid, Converter={StaticResource PercentageConverter}, ConverterParameter='0.6'}">
            <StackPanel Orientation="Vertical" ScrollViewer.CanContentScroll="True">
                <!-- Lots of other WPF Framework elements -->
            </StackPanel>
        </ScrollViewer>
        <ItemsControl Grid.Column="1" ItemsSource="{Binding Tasks}">
            <ItemsControl.Template>
                <ControlTemplate TargetType="{x:Type ItemsControl}" >
                    <ItemsPresenter/>
                </ControlTemplate>
            </ItemsControl.Template>
            <ItemsControl.ItemsPanel>
                <ItemsPanelTemplate>
                    <StackPanel></StackPanel>
                </ItemsPanelTemplate>
            </ItemsControl.ItemsPanel>
            <ItemsControl.ItemTemplate>
                <DataTemplate DataType="cc:Tasks">
                    <StackPanel Orientation="Vertical">
                        <TextBlock Text="{Binding Title}"></TextBlock>
                    </StackPanel>
                </DataTemplate>
            </ItemsControl.ItemTemplate>
        </ItemsControl>
    </Grid>
