    <ItemsControl ItemsSource="{Binding Items}">
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Controls:ItemView />
            </DataTemplate>
        </ItemsControl.ItemTemplate>
        <ItemsControl.Template>
            <ControlTemplate TargetType="ItemsControl">
                <StackPanel>
                    <ItemsPresenter />
                    <Button Content="Add Item"  Click="AddItem_Click"/>
                </StackPanel>
            </ControlTemplate>
        </ItemsControl.Template>
    </ItemsControl>
