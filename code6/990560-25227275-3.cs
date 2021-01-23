    <ItemsControl ItemsSource="{Binding Images}">
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <Grid>
                    <ScrollViewer>
                        <UniformGrid />
                    </ScrollViewer>
                </Grid>
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Image Source="{Binding}" Width="100" Height="100" />
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl> 
