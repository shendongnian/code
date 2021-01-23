    <DataTemplate x:Key="PrepControl">
    <ItemsControl ItemsSource="{Binding Items}" Grid.Column="1" Name="Lst">
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <WrapPanel Orientation="Horizontal"/>
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <StackPanel Orientation="Horizontal">
                    <CheckBox Content="{Binding Description}" 
                                IsChecked="{Binding IsSelected}" 
                                Margin="0,6,8,0">
                        <CheckBox.Style>
                            <Style TargetType="CheckBox">
                                <Style.Triggers>
                                    <Trigger Property="Content" Value="Others">
                                        <Setter Property="ContentTemplate">
                                            <Setter.Value>
                                                <DataTemplate>
                                                    <StackPanel Orientation="Horizontal">
                                                        <TextBlock Text="{Binding}" VerticalAlignment="Center"/>
                                                        <TextBox Margin="5,0" VerticalAlignment="Center"
                                                                    MinWidth="50"
                                                                    IsEnabled="{Binding IsChecked, RelativeSource={RelativeSource AncestorType=CheckBox}}"
                                                                    Text="{Binding Path=DataContext.Others, ElementName=Lst}"/>
                                                    </StackPanel>
                                                </DataTemplate>
                                            </Setter.Value>
                                        </Setter>
                                    </Trigger>
                                </Style.Triggers>
                            </Style>
                        </CheckBox.Style>
                    </CheckBox>
                </StackPanel>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
    </DataTemplate>
