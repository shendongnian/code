    <DataGrid xmlns:sys="clr-namespace:System;assembly=mscorlib">
        <DataGrid.Resources>
            <Style TargetType="DataGridCell">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="DataGridCell">
                            <Border x:Name="border"
                                    BorderThickness="2"
                                    BorderBrush="Silver">
                                <ContentPresenter />
                            </Border>
                            <ControlTemplate.Triggers>
                                <Trigger Property="IsMouseOver"
                                         Value="True">
                                    <Trigger.EnterActions>
                                        <BeginStoryboard>
                                            <Storyboard>
                                                <ColorAnimation Storyboard.TargetName="border"
                                                                Storyboard.TargetProperty="BorderBrush.Color"
                                                                Duration="0:0:0"
                                                                To="Green" />
                                            </Storyboard>
                                        </BeginStoryboard>
                                    </Trigger.EnterActions>
                                    <Trigger.ExitActions>
                                        <BeginStoryboard>
                                            <Storyboard>
                                                <ColorAnimation Storyboard.TargetName="border"
                                                                Storyboard.TargetProperty="BorderBrush.Color"
                                                                Duration="0:0:1"
                                                                To="Silver" />
                                            </Storyboard>
                                        </BeginStoryboard>
                                    </Trigger.ExitActions>
                                </Trigger>
                            </ControlTemplate.Triggers>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </DataGrid.Resources>
        <DataGrid.Columns>
            <DataGridTextColumn Binding="{Binding}"
                                Header="column" />
        </DataGrid.Columns>
        <sys:String>item 1</sys:String>
        <sys:String>item 2</sys:String>
        <sys:String>item 3</sys:String>
        <sys:String>item 4</sys:String>
    </DataGrid>
