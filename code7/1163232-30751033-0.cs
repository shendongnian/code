            <ListView  x:Name="lv" Background="WhiteSmoke" 
                       Height="500" 
                       ItemsSource="{Binding models}">
                <ListView.View>
                    <GridView>
                        <GridViewColumn>
                            <GridViewColumn.CellTemplate>
                                <DataTemplate>
                                    <Image Source="{Binding ImagePath}" 
                                           HorizontalAlignment="Left" 
                                           Stretch="Fill" 
                                           Height="100"
                                           Width="100"/>
                                </DataTemplate>
                            </GridViewColumn.CellTemplate>
                        </GridViewColumn>
                    </GridView>
                </ListView.View>
            </ListView>
