    <TextBox Margin="5" HorizontalAlignment="Stretch">
        <TextBox.ContextMenu>
            <ContextMenu ItemsSource="{Binding Path=FilterProdCountry}">
                <ContextMenu.ItemTemplate>
                    <DataTemplate>
                        <CheckBox Margin="4" HorizontalAlignment="Left"
                                    VerticalAlignment="Center"
                                    IsChecked="{Binding Path=IsSelected, Mode=TwoWay}"
                                    Content="{Binding Path=Description, Mode=OneWay}" />
                    </DataTemplate>
                </ContextMenu.ItemTemplate>
            </ContextMenu>
        </TextBox.ContextMenu>
    </TextBox>
