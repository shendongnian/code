    <Viewbox.Style>
        <Style TargetType="Viewbox">
            <Style.Triggers>
                <MultiDataTrigger>
                    <MultiDataTrigger.Conditions>
                        <Condition Binding="{Binding IsLoaded}" Value="True" />
                        <Condition Binding="{Binding GpoModule}" Value="True" />
                    </MultiDataTrigger.Conditions>
                    <MultiDataTrigger.EnterAction>
                        ... fade in animation
                    </MultiDataTrigger.EnterAction>
                </MultiDataTrigger>
                <MultiDataTrigger>
                    <MultiDataTrigger.Conditions>
                        <Condition Binding="{Binding IsLoaded}" Value="True" />
                        <Condition Binding="{Binding GpoModule}" Value="False" />
                    </MultiDataTrigger.Conditions>
                    <MultiDataTrigger.EnterAction>
                        ... fade out animation
                    </MultiDataTrigger.EnterAction>
                </MultiDataTrigger>
            </Style.Triggers>
        </Style>
    </Viewbox.Style>
