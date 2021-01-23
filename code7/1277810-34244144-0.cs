        <DataGrid>
            <DataGrid.CellStyle>
                <Style TargetType="DataGridCell" >
                    <Setter Property="Template">
                        <Setter.Value>
                            <ControlTemplate TargetType="DataGridCell">
                                <Border Name="cellBorder" BorderBrush="Red">
                                    <Border.Style>
                                        <Style TargetType="Border">
                                            <Style.Triggers>
                                                <DataTrigger Binding="{Binding RelativeSource={RelativeSource TemplatedParent}, Path=Column.DisplayIndex}" Value="2">
                                                    <Setter Property="BorderThickness">
                                                        <Setter.Value>
                                                            <Thickness Left="0" Right="1" Top="0" Bottom="0"/>
                                                        </Setter.Value>
                                                    </Setter>
                                                </DataTrigger>  
                                                <!--put all other necessary triggers here-->
                                            </Style.Triggers>
                                        </Style>                                        
                                    </Border.Style>                                    
                                    <ContentPresenter Content="{Binding RelativeSource={RelativeSource TemplatedParent}, Path=Content}" />
                                </Border>
                            </ControlTemplate>
                        </Setter.Value>
                    </Setter>
                </Style>
            </DataGrid.CellStyle>
        </DataGrid>
