    <TextBox  Grid.Row="1" Text="{Binding tb_property, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" >
                            <i:Interaction.Triggers>
                                <i:EventTrigger EventName="YourEvent">
                                    <cmd:EventToCommand Command="{Binding YourCommandPropertyOnVIewModel}" CommandParameter="OptionalCommandParameter"/>
                                </i:EventTrigger>
                            </i:Interaction.Triggers>
                        </TextBox>
