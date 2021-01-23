    <GridSplitter BorderThickness="1" HorizontalAlignment="Stretch" Grid.Column="1"  >
        <i:Interaction.Triggers>
            <i:EventTrigger EventName="MouseDoubleClick">
                <i:InvokeCommandAction Command="{Binding SplitterClickCommand}"/>
            </i:EventTrigger>
        </i:Interaction.Triggers>
    </GridSplitter>
