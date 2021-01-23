    <Style TargetType="Image">
        <Style.Triggers>        
            <Trigger Property="IsEnabled" Value="True">
                <Trigger.EnterActions>
                    <BeginStoryboard>
                        <Storyboard>
                            <DoubleAnimation Storyboard.TargetProperty="Opacity" From="0.5" To="1" BeginTime="0:0:0" Duration="0:0:1"/>
                        </Storyboard>
                    </BeginStoryboard>
                </Trigger.EnterActions>
                <Trigger.ExitActions>
                    <BeginStoryboard>
                        <Storyboard>
                            <DoubleAnimation Storyboard.TargetProperty="Opacity" From="1" To="0.5" BeginTime="0:0:0" Duration="0:0:1"/>
                        </Storyboard>
                    </BeginStoryboard>
                </Trigger.ExitActions>
            </Trigger>
        </Style.Triggers>
    </Style>
