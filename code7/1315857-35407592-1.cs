     <TextBox Text="{Binding Property1}">
                <TextBox.Style>
                    <Style TargetType="TextBox" BasedOn="{StaticResource {x:Type TextBox}}">
                        <Style.Triggers>
                            <Trigger Property="Visbility" Value="Collapsed">
                                <Trigger.Setters>
                                    <Setter Property="Tag" Value="{Binding Property2}" />
                                    <Setter Property="Tag" Value="{Binding Mode=OneWayToSource,Path=property1}" />
                                </Trigger.Setters>
                            </Trigger>
                        </Style.Triggers>
                    </Style>
                </TextBox.Style>
            </TextBox>
