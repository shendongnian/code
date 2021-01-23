    <Style TargetType="Label">
        <Style.Triggers>
            <DataTrigger Binding="{Binding FlashEnable}" Value="True">
                <Setter Property="Background" Value="Black"/>
                    <Setter Property="Foreground">
                        <Setter.Value>
                            <SolidColorBrush Color="Red"/>
                        </Setter.Value>
                    </Setter>
                <DataTrigger.EnterActions>
                    <BeginStoryboard>
                        <Storyboard RepeatBehavior="Forever">
                            <ColorAnimation
                                Storyboard.TargetProperty="Foreground.Color"
                                Duration="0:0:1" From="Black" To="Red">
                            </ColorAnimation>
                        </Storyboard>
                    </BeginStoryboard>
                </DataTrigger.EnterActions>
            </DataTrigger>
        </Style.Triggers>
    </Style>
