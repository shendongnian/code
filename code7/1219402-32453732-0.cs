       <ListBox Name="lbEurInsuredType" HorizontalContentAlignment="Stretch">
            <ListBox.Template>
                <ControlTemplate>
                    <DockPanel LastChildFill="True">
                        <Grid DockPanel.Dock="Top" Height="30">
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width="100"></ColumnDefinition>
                                <ColumnDefinition Width="30"></ColumnDefinition>
                                <ColumnDefinition Width="2"></ColumnDefinition>
                                <ColumnDefinition Width="30"></ColumnDefinition>
                            </Grid.ColumnDefinitions>
                            <Label Grid.Column="0">Column 1</Label>
                            <Label Grid.Column="1">Column 2</Label>
                            <Label Grid.Column="2">Column 3</Label>
                            <Label Grid.Column="3">Column 4</Label>
                        </Grid>
                        <ItemsPresenter></ItemsPresenter>
                    </DockPanel>
                </ControlTemplate>
            </ListBox.Template>
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <Grid Margin="0,2">
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="100"></ColumnDefinition>
                            <ColumnDefinition Width="30"></ColumnDefinition>
                            <ColumnDefinition Width="2"></ColumnDefinition>
                            <ColumnDefinition Width="30"></ColumnDefinition>
                        </Grid.ColumnDefinitions>
                        <TextBlock Text="{Binding Title}"></TextBlock>
                        <TextBox Text="{Binding Uw}" Grid.Column="1"></TextBox>
                        <TextBox Text="{Binding Partner}" Grid.Column="3"></TextBox>
                    </Grid>
                </DataTemplate>
            </ListBox.ItemTemplate>
        </ListBox>
