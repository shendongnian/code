    <Grid>
            <StackPanel>
                <DataGrid  HeadersVisibility="None" ColumnWidth="*"  ItemsSource="{Binding MyCollection}">
                    <DataGrid.Columns>
                        <DataGridTextColumn Header="First Name"  Binding="{Binding FirstName, Mode=TwoWay, UpdateSourceTrigger=LostFocus}"/>
                        <DataGridTextColumn Header="Last Name" Binding="{Binding LastName, Mode=TwoWay, UpdateSourceTrigger=LostFocus}" />
                    </DataGrid.Columns>
                </DataGrid>
            </StackPanel>
        </Grid>
