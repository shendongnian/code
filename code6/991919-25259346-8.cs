    <DataGrid xmlns:l="clr-namespace:CSharpWPF" xmlns:sys="clr-namespace:System;assembly=mscorlib">
        <DataGrid.Resources>
            <l:SignConverter x:Key="SignConverter" />
            <Style TargetType="DataGridCell">
                <Style.Triggers>
                    <DataTrigger Binding="{Binding Content.Text, RelativeSource={RelativeSource Self}, Converter={StaticResource SignConverter}}"
                                 Value="-1">
                        <Setter Property="Foreground"
                                Value="Red" />
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </DataGrid.Resources>
        <DataGrid.Columns>
            <DataGridTextColumn Header="Numeric Value"
                                Binding="{Binding [0]}" />
            <DataGridTextColumn Header="String Value"
                                Binding="{Binding [1]}" />
        </DataGrid.Columns>
        <x:ArrayExtension Type="{x:Type sys:Object}">
            <sys:Double>-13</sys:Double>
            <sys:String>hello</sys:String>
        </x:ArrayExtension>
        <x:ArrayExtension Type="{x:Type sys:Object}">
            <sys:Double>-1</sys:Double>
            <sys:String>hello 2</sys:String>
        </x:ArrayExtension>
        <x:ArrayExtension Type="{x:Type sys:Object}">
            <sys:Double>1</sys:Double>
            <sys:String>hello 3</sys:String>
        </x:ArrayExtension>
        <x:ArrayExtension Type="{x:Type sys:Object}">
            <sys:Double>0</sys:Double>
            <sys:String>hello 4</sys:String>
        </x:ArrayExtension>
    </DataGrid>
