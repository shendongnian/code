    <DataGrid>
        <i:Interaction.Triggers>
            <i:EventTrigger EventName="CellEditEnding">
                <ec:EventToCommand PassEventArgsToCommand="True"
                                   Command="{Binding ItemEditedCommand}" />
            </i:EventTrigger>
        </i:Interaction.Triggers>
    </DataGrid>
