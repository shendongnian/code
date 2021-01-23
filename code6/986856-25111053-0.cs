    <ListBox Name="list">
      <i:Interaction.Triggers>
        <i:EventTrigger EventName="MouseDoubleClick">
          <Command:EventToCommand
               Command="{Binding Path=DataContext.DoSomethingCommand,ElementName=list}"/>
        </i:EventTrigger>
      </i:Interaction.Triggers>
    </ListBox>
