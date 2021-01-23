      <ListBox Grid.Row="1" ItemsSource="{Binding EmailsCollection}" Margin="5"
                 SelectedItem="{Binding SelectedItem}"
                 IsSynchronizedWithCurrentItem="True">
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <Grid >
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition />
                            <ColumnDefinition />
                        </Grid.ColumnDefinitions>
                        <Grid.RowDefinitions>
                            <RowDefinition />
                            <RowDefinition />
                        </Grid.RowDefinitions>
                        <Label Content="{Binding Sender}" x:Name="SenderLabel">
                            <Label.Style>
                                <Style TargetType="Label">
                                    <Setter Property="FontWeight" Value="Bold"/>
                                    <Style.Triggers>
                                        <DataTrigger Binding="{Binding IsRead}" Value="true">
                                            <Setter Property="FontWeight" Value="Light"/>
                                        </DataTrigger>
                                    </Style.Triggers>
                                </Style>
                            </Label.Style> 
                        </Label>
                        <Label Grid.Row="1" Content="{Binding Subject}" FontSize="12" HorizontalAlignment="Left" />
                        <Label Grid.Column="1" Content="{Binding Date}" FontSize="12" HorizontalAlignment="Right" />
                    </Grid>
                </DataTemplate>
            </ListBox.ItemTemplate>
        </ListBox>
