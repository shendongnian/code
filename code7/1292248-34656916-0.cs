    <ItemsControl ItemsSource="{Binding Path=People}">
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Border Name="Border"  BorderBrush="Gray" BorderThickness="1" CornerRadius="4" Margin="2">
                    <i:Interaction.Triggers>
                        <i:EventTrigger EventName="Loaded">
                            <i:Interaction.Behaviors>
                                <ei:ConditionBehavior>
                                    <ei:ConditionalExpression>
                                        <ei:ComparisonCondition LeftOperand="{Binding IsEnabled}" RightOperand="True"/>
                                    </ei:ConditionalExpression>
                                </ei:ConditionBehavior>
                            </i:Interaction.Behaviors>
                            <ei:ControlStoryboardAction ControlStoryboardOption="Play">
                                <ei:ControlStoryboardAction.Storyboard>
                                    <Storyboard>
                                        <DoubleAnimation Storyboard.TargetName="Border" From="0.01" To="1" Storyboard.TargetProperty="Opacity" Duration="0:0:2"/>
                                    </Storyboard>
                                </ei:ControlStoryboardAction.Storyboard>
                            </ei:ControlStoryboardAction>    
                        </i:EventTrigger>
                    </i:Interaction.Triggers>
    
                    <TextBlock Text="{Binding Path=Surname, Mode=OneWay}" Margin="2" />
                </Border>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
