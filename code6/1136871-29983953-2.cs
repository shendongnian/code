    <Window.DataContext>
        <vm:ViewModel /> <!--Or set the DataContext in another way-->
    </Window.DataContext>
    <StackPanel>
        <ListBox x:Name="lbPostAwr" ItemsSource="{Binding ClientRatesPostAwr}">
            <ItemsControl.ItemContainerStyle>
                <Style TargetType="ListBoxItem">
                </Style>
            </ItemsControl.ItemContainerStyle>
            <ItemsControl.ItemsPanel>
                <ItemsPanelTemplate>
                    <StackPanel Orientation="Vertical"/>
                </ItemsPanelTemplate>
            </ItemsControl.ItemsPanel>
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <Grid Margin="0" Focusable="False">
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition />
                            <ColumnDefinition />
                        </Grid.ColumnDefinitions>
                        <Label Grid.Column="0" Content="{Binding Description}" />
                        <TextBox Grid.Column="1" Text="{Binding Value}" />
                    </Grid>
                </DataTemplate>
            </ItemsControl.ItemTemplate>
        </ListBox>
        <Button Content="Save" Command="{Binding SaveCommand, Mode=OneWay}" />
    </StackPanel>
    
