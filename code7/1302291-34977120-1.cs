    <DataTrigger Binding="{Binding Path=ControlSizeDefinition.ImageSize, RelativeSource={RelativeSource Mode=Self}}" Value="Large">
        <Setter Property="FrameworkElement.MinWidth">
            <Setter.Value>
                <s:Double>44</s:Double>
            </Setter.Value>
        </Setter>
        <Setter Property="FrameworkElement.Height">
            <Setter.Value>
                <s:Double>66</s:Double>
            </Setter.Value>
        </Setter>
        <Setter Property="FrameworkElement.MinHeight" TargetName="Grid">
            <Setter.Value>
                <s:Double>26</s:Double>
            </Setter.Value>
        </Setter>
        <Setter Property="RibbonTwoLineText.HasTwoLines" TargetName="TwoLineText">
            <Setter.Value>
                <s:Boolean>True</s:Boolean>
            </Setter.Value>
        </Setter>
    </DataTrigger>
