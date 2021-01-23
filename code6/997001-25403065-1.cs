    <TextBlock IsEnabled="{Binding LinkEnabled}">
        <Hyperlink IsEnabled="{Binding IsEnabled, RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type FrameworkElement}}}"
                   ToolTip="ToolTip"
                   ToolTipService.ShowOnDisabled="True"
                   ToolTipService.IsEnabled="{Binding IsEnabled, RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type FrameworkElement}}, Converter={StaticResource negateConverter}}">
            <TextBlock Text="{Binding Text}"/>
        </Hyperlink>
    </TextBlock>
