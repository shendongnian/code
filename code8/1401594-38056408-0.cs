    <TabControl Grid.Row="0" Name="TabDynamic" 
                ItemsSource="{Binding TabItems, Mode=OneWay}" 
                SelectionChanged="tabDynamic_SelectionChanged">
        <TabControl.Resources>
            <DataTemplate x:Key="TabHeader" DataType="TabItem">
                <DockPanel>
                    <TextBlock Text="{Binding RelativeSource={RelativeSource AncestorType={x:Type TabItem}}, Path=Header}" />
                    <Button Name="btnDelete" DockPanel.Dock="Right" Margin="5,0,0,0" Padding="0" Click="btnTabDelete_Click" CommandParameter="{Binding RelativeSource={RelativeSource AncestorType={x:Type TabItem}}, Path=Name}">
                        <Image Source="{DynamicResource DeleteImg}" Height="11" Width="11"></Image>
                    </Button>
                </DockPanel>
            </DataTemplate>
            <DataTemplate x:Key="TabContent" DataType="viewModels:ConnectionInfoVM">
                <TabItem Header="{Binding ConnectionID, Mode=OneWay}"
                         Name="{Binding ConnectionID, Mode=OneWay}"
                         HeaderTemplate="{StaticResources TabHeader}"
                         ContentTemplate ="{StaticResources TabContent}">
                    <StackPanel>
                        <ScrollViewer Name="Scroller" Background="Black">
                            <StackPanel>
                                <TextBlock Text="This line gets printed" Foreground="White" FontFamily="Consolas"/>
                                <ItemsControl Name="ItemCtrl" ItemsSource="{Binding DataBuffer}">
                                    <ItemsControl.ItemTemplate>
                                        <DataTemplate>
                                            <TextBlock Text="{Binding Path=.}" Foreground="White" FontFamily="Consolas"/>
                                        </DataTemplate>
                                    </ItemsControl.ItemTemplate>
                                </ItemsControl>
                            </StackPanel>
                        </ScrollViewer>
                    </StackPanel>
                </TabItem>
                
            </DataTemplate>
        </TabControl.Resources>
    </TabControl>
