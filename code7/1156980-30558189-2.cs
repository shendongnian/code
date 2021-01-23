        <ItemsControl Grid.Row="0" x:Name="gridSubfolders" ItemsSource="{Binding SubfolderNames}" Grid.IsSharedSizeScope="True">
            <ItemsControl.ItemsPanel>
                <ItemsPanelTemplate>
                    <WrapPanel></WrapPanel>
                </ItemsPanelTemplate>
            </ItemsControl.ItemsPanel>
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="Auto" SharedSizeGroup="50" />
                        </Grid.ColumnDefinitions>
                        <Border Margin="5" BorderThickness="1" BorderBrush="Black">
                            <CheckBox Content="{Binding}"/>
                        </Border>
                    </Grid>
                </DataTemplate>
            </ItemsControl.ItemTemplate>
        </ItemsControl>
