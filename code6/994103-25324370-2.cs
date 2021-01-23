        <DataGrid>
            <DataGrid.Resources>
                <Style TargetType="DataGridRow">
                    <Setter Property="Background"
                            Value="YellowGreen" />
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding}"
                                     Value="item 1">
                            <Setter Property="Background"
                                    Value="Pink" />
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </DataGrid.Resources>
            <DataGrid.Columns>
                <DataGridTextColumn Binding="{Binding}"
                                    Header="A Column" />
                <DataGridTextColumn Binding="{Binding Length}"
                                    Header="Length" />
            </DataGrid.Columns>
            <sys:String>item 1</sys:String>
            <sys:String>item 2</sys:String>
            <sys:String>item 1</sys:String>
            <sys:String>item 2</sys:String>
            <sys:String>item 2</sys:String>
            <sys:String>item 2</sys:String>
        </DataGrid>
