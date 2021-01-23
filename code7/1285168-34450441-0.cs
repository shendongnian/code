     <Grid x:Name="DynamicJoystickWindow" RenderTransformOrigin="0.5,0.5" Background="Blue">
                    <i:Interaction.Triggers>
    
                        <i:EventTrigger EventName="PreviewMouseUp" >
                            <command:EventToCommand Command="{Binding JoystickMouseUp_Dynamic}" PassEventArgsToCommand="True" />
                        </i:EventTrigger>
    
                        <i:EventTrigger EventName="PreviewMouseDown">
                            <command:EventToCommand Command="{Binding JoystickMouseDown_Dynamic}" PassEventArgsToCommand="True" />
                        </i:EventTrigger>
    
                        <i:EventTrigger EventName="PreviewMouseMove" >
                            <command:EventToCommand Command="{Binding JoystickMouseMove_Dynamic}" PassEventArgsToCommand="True" />
                        </i:EventTrigger>
    
                    </i:Interaction.Triggers>
            </Grid>
