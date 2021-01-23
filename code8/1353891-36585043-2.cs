    <ListBox ItemsSource="{Binding Items}" >
        <ListBox.ItemTemplate>
            <DataTemplate>
                <Grid>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="30"/>
                        <ColumnDefinition Width="150"/>
                        <ColumnDefinition/>
                        <ColumnDefinition Width="50"/>
                        <ColumnDefinition Width="30"/>
                    </Grid.ColumnDefinitions>
                    <Button x:Name="DelOutConBT" Margin="5" Content="X" Click=" Delete ConnSet"/>
                    <Label x:Name="OutConLB" Grid.Column="1" ></Label>
                    <ComboBox x:Name="InConComB" Grid.Column="2"></ComboBox>
                    <TextBox x:Name="ConnValueTX" Grid.Column="3" Margin="5"></TextBox>
                    <Button Grid.Column="4" Margin="5" Content=">>"></Button>
                </Grid>
            </DataTemplate>
        </ListBox.ItemTemplate>
    </ListBox>
