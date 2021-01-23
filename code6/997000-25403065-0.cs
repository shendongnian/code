    <TextBlock>
        <Hyperlink IsEnabled="{Binding LinkEnabled}"
                   ToolTip="ToolTip"
                   ToolTipService.ShowOnDisabled="True"
                   ToolTipService.IsEnabled="{Binding IsEnabled, RelativeSource={RelativeSource Self}, Converter={StaticResource negateConverter}}">
            <TextBlock Text="{Binding Text}"/>
        </Hyperlink>
    </TextBlock>
