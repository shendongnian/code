    <Style TargetType="Image" x:Key="PressableImage">
        <Setter Property="RenderTransformOrigin" Value="0.5,0.5"/>
        <Setter Property="RenderTransform">
            <Setter.Value>
                    <ScaleTransform ScaleX="1" ScaleY="1" />
            </Setter.Value>
        </Setter>
        <Style.Triggers>
            <EventTrigger RoutedEvent="MouseDown">
                <BeginStoryboard>
                    <Storyboard >
                        <DoubleAnimation Storyboard.TargetProperty="RenderTransform.ScaleX" From="1" To="0.9" Duration="0:0:0.03" />
                        <DoubleAnimation Storyboard.TargetProperty="RenderTransform.ScaleX" From="0.9" To="1" BeginTime="0:0:0.03" Duration="0:0:0.1" />
                        <DoubleAnimation Storyboard.TargetProperty="RenderTransform.ScaleY" From="1" To="0.9" Duration="0:0:0.03" />
                        <DoubleAnimation Storyboard.TargetProperty="RenderTransform.ScaleY" From="0.9" To="1" BeginTime="0:0:0.03" Duration="0:0:0.1" />
                    </Storyboard>
                </BeginStoryboard>
            </EventTrigger>
        </Style.Triggers>
    </Style>
