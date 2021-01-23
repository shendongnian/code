    <ItemsControl ItemsSource="{Binding SomeMatrix}">
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <UniformGrid IsItemsHost="True" Columns="{Binding SomeMatrix.Columns}" />
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Label Content="{Binding}" HorizontalContentAlignment="Center" />
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
