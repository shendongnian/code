    <Window.Resources>
        <Style x:Key="Test"
               TargetType="Button">
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="Button">
                        <StackPanel>
                            <TextBlock x:Name="text"
                                       Text="dummy" />
                            <TextBlock x:Name="demo"
                                       Text="{Binding RelativeSource={RelativeSource TemplatedParent}}" />
                        </StackPanel>
                        <ControlTemplate.Triggers>
                            <DataTrigger Binding="{Binding RelativeSource={RelativeSource TemplatedParent}, Path=Content}">
                                <DataTrigger.Value>
                                    <system:String>Test</system:String>
                                </DataTrigger.Value>
                                <Setter TargetName="text"
                                        Property="Foreground"
                                        Value="Red" />
                            </DataTrigger>
                        </ControlTemplate.Triggers>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
        <Style x:Key="Test2" TargetType="ContentControl">
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="ContentControl">
                        <Button Style="{StaticResource Test}"></Button>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
    </Window.Resources>
    <Grid>
        <!--<Button Content="Test" Style="{StaticResource Test}"/>-->
        <ContentControl Style="{StaticResource Test2}" Content="Test" />
    </Grid>
