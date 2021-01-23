    <ItemsControl Name="NavButtonsItemsControl" ItemsSource="{Binding NavBarButtons}">
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <StackPanel Orientation="Horizontal" />
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Button Content="{Binding ButtonContent}" CommandParameter="{Binding ButtonModuleType}" Command="{Binding ButtonCommand}"/>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
        
    </ItemsControl>
