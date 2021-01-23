     <ListView Name="lbEurInsuredType" HorizontalContentAlignment="Stretch" ItemsSource="{Binding Items}">
            <ListView.View>
                <GridView>
                    <GridView.Columns>
                        <GridViewColumn>
                            <GridViewColumn.CellTemplate>
                                <DataTemplate>
                                    <TextBlock Text="{Binding Title}"></TextBlock>
                                </DataTemplate>
                            </GridViewColumn.CellTemplate>
                            <GridViewColumn.Header>
                                <TextBlock Text="Column 1"></TextBlock>
                            </GridViewColumn.Header>
                        </GridViewColumn>
                        <GridViewColumn>
                            <GridViewColumn.CellTemplate>
                                <DataTemplate>
                                    <TextBlock Text="{Binding Uw}"></TextBlock>
                                </DataTemplate>
                            </GridViewColumn.CellTemplate>                           
                        </GridViewColumn>
                        <GridViewColumn>
                            <GridViewColumn.CellTemplate>
                                <DataTemplate>
                                    <TextBlock Text="{Binding Partner}"></TextBlock>
                                </DataTemplate>
                            </GridViewColumn.CellTemplate>
                            <GridViewColumn.Header>
                                <TextBlock Text="Column 3"></TextBlock>
                            </GridViewColumn.Header>
                        </GridViewColumn>
                    </GridView.Columns>
                </GridView>
            </ListView.View>                      
        </ListView>
