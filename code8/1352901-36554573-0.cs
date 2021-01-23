    <ListView ItemsSource="{Binding}"  Name="listView1">
            <ListView.View>
                <GridView>
                    <GridViewColumn Header="By" DisplayMemberBinding="{Binding Name}"/>
                    <GridViewColumn Header="HI">
                        <GridViewColumn.CellTemplate>
                            <DataTemplate>
                                <ComboBox Name="comboBox1"  Width="60" >
                                    <ComboBox.Items>
                                        <ComboBoxItem Content="Item1"/>
                                        <ComboBoxItem Content="Item2"/>
                                    </ComboBox.Items>
                                </ComboBox>
                            </DataTemplate>
                        </GridViewColumn.CellTemplate>
                    </GridViewColumn>
                </GridView>
            </ListView.View>
        </ListView>
