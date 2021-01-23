    <StackPanel Orientation="Vertical">
        <CheckBox 
            x:Name="EnableButton1CheckBox" 
            Content="Enable Button1" 
            Margin="4"
            />
        <Grid
            Margin="4"
            >
            <Button 
                Content="Button1"
                x:Name="button1"
                IsEnabled="{Binding IsChecked, ElementName=EnableButton1CheckBox}"
                >
            </Button>
            <!-- 
            When button1 is disabled, it can't receive mouse events, so we create a 
            coextensive control that's explicitly transparent. If it merely had no  
            background specified, it wouldn't get mouse events either. 
            -->
            <Border
                x:Name="Button1MouseDetector"
                Background="Transparent"
                >
                <Border.Style>
                    <Style TargetType="Border">
                        <Style.Triggers>
                            <Trigger Property="IsMouseOver" Value="True">
                                <Setter Property="Tag" Value="MouseOver" />
                            </Trigger>
                        </Style.Triggers>
                    </Style>
                </Border.Style>
            </Border>
        </Grid>
        <Button 
            Content="Button2"
            x:Name="button2"
            Margin="4"
            >
            <Button.Style>
                <Style TargetType="Button" BasedOn="{StaticResource {x:Type Button}}">
                    <Style.Triggers>
                        <MultiDataTrigger>
                            <MultiDataTrigger.Conditions>
                                <Condition 
                                    Binding="{Binding Tag, ElementName=Button1MouseDetector}" 
                                    Value="MouseOver" 
                                    />
                                <Condition 
                                    Binding="{Binding IsEnabled, ElementName=button1}" 
                                    Value="False" 
                                    />
                            </MultiDataTrigger.Conditions>
                            <Setter Property="BorderBrush" Value="Red" />
                        </MultiDataTrigger>
                    </Style.Triggers>
                </Style>
            </Button.Style>
        </Button>
    </StackPanel>
