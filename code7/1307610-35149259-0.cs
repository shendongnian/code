    <MultiTrigger>
        <MultiTrigger.Conditions>
            <Condition Property="IsSelected" Value="True" />
            <Condition Property="Selector.IsSelectionActive" Value="False" />
        </MultiTrigger.Conditions>
        <Setter Property="Background" Value="{DynamicResource GrayBrush7}" />
    </MultiTrigger>
