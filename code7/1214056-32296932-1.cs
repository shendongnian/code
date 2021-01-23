     <DataGrid>
           <DataGrid.Columns>
                <DataGridTextColumn Header="Name" Binding="{Binding Name}">
                    <DataGridTextColumn.CellStyle>
                        <Style TargetType="DataGridCell" BasedOn="{StaticResource {x:Type DataGridCell}}" >
                            <Setter Property="Background">
                               <Setter.Value>
                                    <MultiBinding Converter="{StaticResource NameToBrushMultiConverter}" UpdateSourceTrigger="PropertyChanged">
                                      <Binding Path="Name" />
                                      <Binding Path="FirstName" />
                                    </MultiBinding>
                               </Setter.Value>
                            </Setter>                            
                        </Style>
                    </DataGridTextColumn.CellStyle>
                </DataGridTextColumn>
            </DataGrid.Columns>
       </DataGrid> 
