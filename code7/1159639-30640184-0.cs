    <i:Interaction.Triggers>
        <i:EventTrigger EventName="KeyDown">
            <command:EventToCommand Command="{Binding Path=TestCommand}"  PassEventArgsToCommand="True"/>
         </i:EventTrigger>
    </i:Interaction.Triggers>
    public RelayCommand<KeyEventArgs> Command { get; private set; }
