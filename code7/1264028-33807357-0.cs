    <ToggleButton Content="Switch" Name="chk"/>
        
    <Rectangle Fill="Red" Name="rect"
                Width="50" Height="50">
        <Rectangle.Style>
            <Style TargetType="Rectangle">
                <Style.Triggers>
                    <DataTrigger Binding="{Binding IsChecked, ElementName=chk}" Value="False">
                        <DataTrigger.EnterActions>
                            <BeginStoryboard>
                                <Storyboard 
                                    Storyboard.TargetProperty="Opacity">
                                    <DoubleAnimation From="1"
                                                        To="0"/>
                                </Storyboard>
                            </BeginStoryboard>
                        </DataTrigger.EnterActions>
                        <DataTrigger.ExitActions>
                            <BeginStoryboard>
                                <Storyboard 
                                    Storyboard.TargetProperty="Opacity">
                                    <DoubleAnimation From="0"
                                                        To="1"/>
                                </Storyboard>
                            </BeginStoryboard>
                        </DataTrigger.ExitActions>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </Rectangle.Style>
    </Rectangle>
