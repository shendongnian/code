        <ItemsControl x:Name="ItemsControl" ItemsSource="{Binding Path=Items}">
                <ItemsControl.ItemsPanel>
                    <ItemsPanelTemplate>
                        <WrapPanel/>
                    </ItemsPanelTemplate>
                </ItemsControl.ItemsPanel>
                <ItemsControl.Resources>
                    <DataTemplate DataType="{x:Type local:Type1}">
                        <StackPanel>
                            <TextBlock Text="{Binding Property1}"/>
                            <TextBlock Text="{Binding Path=Property2, Mode=OneWay}"/>
                        </StackPanel>
                    </DataTemplate>
                </ItemsControl.Resources>
            </ItemsControl>
        </Imagin.Photos.Controls:Viewer>
