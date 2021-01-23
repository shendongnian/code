    <ItemsControl ItemsSource="{Binding Inventory}">
        <ItemsControl.Resources>
            <DataTemplate DataType="{x:Type views:InventoryItem}">
                <StackPanel>
                    <Grid >
                        <Button Content="{Binding Path=Name}" Click="ButtonBase_OnClick"/>
                    </Grid>
                </StackPanel>
            </DataTemplate>
            <DataTemplate DataType="{x:Type views:InventoryNewItem}">
                <StackPanel>
                    <Grid >
                        <Button Content="+" Background="Green" Click="Add_OnClick"/>
                    </Grid>
                </StackPanel>
            </DataTemplate>                    
        </ItemsControl.Resources>
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <WrapPanel MaxHeight="{Binding ElementName=window, Path=Height}" 
                           Orientation="Vertical"/>
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
    </ItemsControl>
