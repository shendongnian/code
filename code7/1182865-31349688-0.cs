    <Button Content="Color change" Background="{Binding BackGround}" Command="{Binding ButtonPressedCommand}">
            <Button.Template>
                <ControlTemplate TargetType="Button">
                    <Border Name="Border" Background="{Binding RelativeSource={RelativeSource TemplatedParent}, Path=Background, Mode=OneWay}">
                        <ContentPresenter HorizontalAlignment="Center" VerticalAlignment="Center"/>
                    </Border>
                    <ControlTemplate.Triggers>
                        <Trigger Property="IsMouseOver" Value="True">
                            <Setter Property="Background" TargetName="Border" 
                                    Value="{Binding BackGroundOnHover}"/>
                        </Trigger>
                        <Trigger Property="IsMouseOver" Value="False">
                            <Setter Property="Background" TargetName="Border" 
                                    Value="{Binding BackGround}"/>
                        </Trigger>
                    </ControlTemplate.Triggers>
                </ControlTemplate>
            </Button.Template>
        </Button>
