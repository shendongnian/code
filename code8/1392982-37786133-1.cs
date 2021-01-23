    <Setter Property="ToolTip">
        <Setter.Value>
            <ToolTip>
                <templates:MyToolTipTemplate SomeBoolProperty="{Binding StaysOpen,
                            RelativeSource={RelativeSource AncestorType=ToolTip}}"/>
            </ToolTip>
        </Setter.Value>
    </Setter>
