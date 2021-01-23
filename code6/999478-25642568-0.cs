    <TextBox Text="{Binding TextField, UpdateSourceTrigger=PropertyChanged}">
        <i:Interaction.Triggers>
            <i:EventTrigger EventName="LostFocus">
                <i:EventTrigger.Actions>
                    <i:InvokeCommandAction Command="{Binding SaveCommand}"/>
                </i:EventTrigger.Actions>
            </i:EventTrigger>
        </i:Interaction.Triggers>
    </TextBox>
