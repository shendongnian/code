    <ListView x:Name="listViewRoles" Margin="10,146,20,0" IsSynchronizedWithCurrentItem="False" >
                <ListView.View>
                    <GridView>
                        <GridView.ColumnHeaderContainerStyle>
                            <Style TargetType="{x:Type GridViewColumnHeader}">
                                <Setter Property="IsEnabled" Value="False"/>
                            </Style>
                        </GridView.ColumnHeaderContainerStyle>
    
                        <GridViewColumn Header="Stato" Width="50">
                            <GridViewColumn.CellTemplate>
                                <DataTemplate>
                                    <Image x:Name="Image_GridViewColumnName" Width="20" Height="20" Source="{Binding GridViewColumnName_ImageSource}" />
                                </DataTemplate>
                            </GridViewColumn.CellTemplate>
                        </GridViewColumn>
                        <GridViewColumn  Header="Regola" Width="400">
                            <GridViewColumn.CellTemplate>
                                <DataTemplate>
                                    <TextBlock Text="{Binding GridViewColumnName_LabelContent}" Width="400" Height="20"/>
                                </DataTemplate>
                            </GridViewColumn.CellTemplate>
                        </GridViewColumn>
                        <GridViewColumn  Header="Risultato" Width="320">
                            <GridViewColumn.CellTemplate>
                                <DataTemplate>
                                    <Label Content="{Binding GridViewColumnResult}"/>
                                </DataTemplate>
                            </GridViewColumn.CellTemplate>
                        </GridViewColumn>
                    </GridView>
                </ListView.View>
            </ListView>
