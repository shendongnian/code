    <ListView x:Name="listViewRoles" Margin="10,146,20,0" IsSynchronizedWithCurrentItem="False" >
                <ListView.ItemContainerStyle>
                    <Style TargetType="ListViewItem">
                        <Setter Property="Height" Value="20"/>
                    </Style>
                </ListView.ItemContainerStyle>
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
                        <GridViewColumn  Header="Regola" Width="400" DisplayMemberBinding="{Binding GridViewColumnName_LabelContent}"/>
                        <GridViewColumn  Header="Risultato" Width="320" DisplayMemberBinding="{Binding GridViewColumnResult}"/>
                    </GridView>
                </ListView.View>
            </ListView>
