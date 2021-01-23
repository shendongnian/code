    <TabControl ItemsSource="{Binding Tabs}">
        <TabControl.ItemContainerStyle>
            <Style TargetType="TabItem">
                <Setter Property="HeaderTemplate">
                    <Setter.Value>
                        <DataTemplate DataType="local:TabViewModel">
                            <StackPanel Orientation="Horizontal" Margin="5">
                                <Image x:Name="Icon" Source="{Binding Icon, Converter={StaticResource UriToBitmapSourceConverter}}" />
                                <Rectangle x:Name="ColorRect" Height="16" Width="16" Fill="{Binding Color}" Visibility="Collapsed" />
                                <TextBlock Text="{Binding Title}" Foreground="{Binding Color}"/>
                            </StackPanel>
                            <DataTemplate.Triggers>
                                <DataTrigger Binding="{Binding Icon}" Value="{x:Null}">
                                    <Setter TargetName="Icon" Property="Visibility" Value="Collapsed" />
                                    <Setter TargetName="ColorRect" Property="Visibility" Value="Visible" />
                                </DataTrigger>
                            </DataTemplate.Triggers>
                        </DataTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </TabControl.ItemContainerStyle>
    </TabControl>
