    <TextBox Text="{Binding Property1}" Tag="{Binding Mode=OneWayToSource,Path=Property1}">
            <TextBox.Style>
                <Style TargetType="TextBox" BasedOn="{StaticResource {x:Type TextBox}}">
                    <Style.Triggers>
                        <Trigger Property="Visbility" Value="Collapsed">
                            <Trigger.Setters>
                                <Setter Property="Tag" Value="{Binding Property2}" />
                            </Trigger.Setters>
                        </Trigger>
                    </Style.Triggers>
                </Style>
            </TextBox.Style>
        </TextBox>
