    <ListView Name="PlotLista"    SelectedIndex="{Binding SelectedValue}" ItemsSource="{Binding PlotModelList}" HorizontalAlignment="Stretch" VerticalAlignment="Stretch" Tag="{Binding DataContext,ElementName=theViewName}">
                <ListView.ItemTemplate>
                    <DataTemplate>
                        <oxy:Plot  MinHeight="260" Height="Auto"   IsRendering="True" FontStyle="Normal" FontFamily="Arial" FontSize="8"  VerticalContentAlignment="Top"  HorizontalContentAlignment="Left" Width="{Binding RelativeSource={RelativeSource Mode=FindAncestor, AncestorType={x:Type UserControl}}, Path=ActualWidth}"  Model="{Binding }">
                            <oxy:Plot.ContextMenu>
                                <ContextMenu DataContext="{Binding PlacementTarget.Tag, RelativeSource={RelativeSource Self}}">
                                    <MenuItem Header="Export to PNG" Command="{Binding DataContext.SavePNG}"/>
                                </ContextMenu>
                            </oxy:Plot.ContextMenu>
                        </oxy:Plot>
                    </DataTemplate>
                </ListView.ItemTemplate>
            </ListView>
