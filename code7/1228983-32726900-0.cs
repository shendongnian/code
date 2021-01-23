    <ItemsControl ItemsSource="{Binding Servers, Mode=OneWay}">
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <WrapPanel />
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Border BorderBrush="Black" BorderThickness="1" Margin="5,5,5,5">
                    <local:ServerControl DataContext="{Binding }" /> <!-- The actual UserControl -->
                </Border>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
        <ItemsControl.Template>
            <ControlTemplate TargetType="{x:Type ItemsControl}">
                <ScrollViewer VerticalScrollBarVisibility="Auto">
                    <ItemsPresenter />
                </ScrollViewer>
            </ControlTemplate>
        </ItemsControl.Template>
    </ItemsControl>
