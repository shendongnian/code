        <ItemsControl ItemsSource="{Binding GameBoard.CardList}">
            <ItemsControl.ItemsPanel>
                <ItemsPanelTemplate>
                    <UniformGrid IsItemsHost="True" />
                </ItemsPanelTemplate>
            </ItemsControl.ItemsPanel>
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <Button Command="{Binding DataContext.SelectCardCommand, RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=ItemsControl}}"
                            CommandParameter="{Binding}">
                        <Button.Template>
                            <ControlTemplate>
                                <Rectangle Fill="{Binding Converter={StaticResource ColorConverter}}"
                                           Height="100"
                                           Width="100"
                                           Margin="10,10,0,0"
                                           Stroke="Black">
                                </Rectangle>
                            </ControlTemplate>
                        </Button.Template>
                    </Button>
                </DataTemplate>
            </ItemsControl.ItemTemplate>
        </ItemsControl>
