    <StackPanel>
                <Button Content="Click me" Width="80" Height="20" Command="{Binding IncreaseSizeCommand}"/>
                <ItemsControl
                    Grid.Row="0"
                    ItemsSource="{Binding RectItems}">
                    <ItemsControl.ItemsPanel>
                        <ItemsPanelTemplate>
                            <Canvas Height="{Binding PanelHeight, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}"
                                    Width="{Binding PanelWidth, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}"/>
                        </ItemsPanelTemplate>
                    </ItemsControl.ItemsPanel>
                    <ItemsControl.ItemContainerStyle>
                        <Style TargetType="ContentPresenter">
                            <Setter Property="Canvas.Left" Value="{Binding X}" />
                            <Setter Property="Canvas.Top" Value="{Binding Y}" />
                        </Style>
                    </ItemsControl.ItemContainerStyle>
                    <ItemsControl.ItemTemplate>
                        <DataTemplate>
                            <Rectangle
                                Width="{Binding Width}"
                                Height="{Binding Height}"
                                Fill="{Binding Color}" />
                        </DataTemplate>
                    </ItemsControl.ItemTemplate>
                </ItemsControl>
    </StackPanel>
