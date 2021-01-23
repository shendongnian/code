        <TextBox x:Name="Foo1"/>
        <TextBox x:Name="Foo2"/>
        <Button Content="Push me">
            <Button.Style>
                <Style TargetType="{x:Type Button}">
                    <Style.Triggers>
                        <MultiDataTrigger>
                            <MultiDataTrigger.Conditions>
                                <Condition Binding="{Binding Text.Length, ElementName=Foo1, UpdateSourceTrigger=PropertyChanged}" Value="0"/>
                                <Condition Binding="{Binding Text.Length, ElementName=Foo2, UpdateSourceTrigger=PropertyChanged}" Value="0"/>
                            </MultiDataTrigger.Conditions>
                            <Setter Property="IsEnabled" Value="False"/>
                        </MultiDataTrigger>
                    </Style.Triggers>
                </Style>
            </Button.Style>
        </Button>
