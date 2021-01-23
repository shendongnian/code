    <DataGrid ItemsSource="{Binding}">
        <DataGrid.CellStyle>
            <Style TargetType="DataGridCell" >
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="DataGridCell">
                            <Border Name="rowBorder" BorderBrush="Red">
                                <Border Name="columnBorder" BorderBrush="Red">
                                    <Border.Style>
                                        <Style TargetType="Border">
                                            <Style.Triggers>
                                                <DataTrigger Binding="{Binding RelativeSource={RelativeSource TemplatedParent}, Path=Column.DisplayIndex}" Value="2">
                                                    <Setter Property="BorderThickness">
                                                        <Setter.Value>
                                                            <Thickness Left="1" Right="0" Top="0" Bottom="0"/>
                                                        </Setter.Value>
                                                    </Setter>
                                                </DataTrigger>
                                                <!--put column related triggers here-->
                                            </Style.Triggers>
                                        </Style>
                                    </Border.Style>
                                    <ContentPresenter Content="{Binding RelativeSource={RelativeSource TemplatedParent}, Path=Content}" />
                                </Border>
                                <Border.Style>
                                    <Style TargetType="Border">
                                        <Style.Triggers>
                                            <DataTrigger Binding="{Binding RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=DataGridRow}, Converter={x:Static local:RowToIndexConverter.Instance}}" Value="1">
                                                <Setter Property="BorderThickness">
                                                    <Setter.Value>
                                                        <Thickness Left="0" Right="0" Top="1" Bottom="0"/>
                                                    </Setter.Value>
                                                </Setter>
                                            </DataTrigger>
                                            <!--put row related triggers here-->
                                        </Style.Triggers>
                                    </Style>
                                </Border.Style>                                    
                            </Border>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </DataGrid.CellStyle>
    </DataGrid>
