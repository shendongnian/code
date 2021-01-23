    <TextBox>
                <interactivity:Interaction.Triggers>
                    <interactivity:EventTrigger EventName="TextChanged">
                        <behaviours:ExecuteCommandAction Command="{Binding Path=DataContext.ValidateCommand, 
    																		   RelativeSource={RelativeSource FindAncestor,
    																						                  AncestorType={x:Type UserControl}}}"
                                                         CommandParameter="PassTheColumnHere"/>
                    </interactivity:EventTrigger>
                </interactivity:Interaction.Triggers>
            </TextBox>
