    <DataGrid AutoGenerateColumns="False">
                <DataGrid.Columns>
                    <DataGridTemplateColumn>
                        <DataGridTemplateColumn.CellTemplate>
                            <DataTemplate>
                                <StackPanel>
                                    <StackPanel Orientation="Horizontal">
                                        <TextBlock Text="OrderId : "/>
                                        <TextBlock Text="{Binding OrderId}"/>
                                    </StackPanel>
                                    <StackPanel Orientation="Horizontal">
                                        <TextBlock Text="OrderTime : "/>
                                        <TextBlock Text="{Binding OrderTime}"/>
                                    </StackPanel>
                                    <StackPanel Orientation="Horizontal">
                                        <TextBlock Text="OrderStatus : "/>
                                        <TextBlock Text="{Binding OrderStatus}"/>
                                    </StackPanel>
    
    				<StackPanel Orientation="Horizontal">
                                        <Image Width="250px" Height="50px" Margin="3,0">
                                          <Image.Style>
                                           <Style TargetType="{x:Type Image}">
                                           <Style.Triggers>
                                           <DataTrigger Binding="{Binding OrderStatus}" Value="New">
                                           <Setter Property="Source" Value="/Images/New.png"/>
                                           </DataTrigger>
                                          <DataTrigger Binding="{Binding OrderStatus}" Value="Old">
                                          <Setter Property="Source" Value="/Images/Old.png"/>
                                          </DataTrigger>
                                          </Style.Triggers>
                                         </Style>
                                        </Image.Style>
                                       </Image>
                                   </StackPanel>
    
                                </StackPanel>
                            </DataTemplate>
                        </DataGridTemplateColumn.CellTemplate>
                    </DataGridTemplateColumn>
                </DataGrid.Columns>
            </DataGrid>
