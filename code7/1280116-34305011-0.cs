    <Button ...>
        <Button.Style>
            <Style TargetType="Button">
                <Style.Triggers>
                    <Trigger Property="IsFocused" Value="True">
                        <Setter Property="Background" Value="Red"/>
                    </Trigger>
                </Style.Triggers>
            </Style>
        </Button.Style>
        <i:Interaction.Triggers>
            <i:EventTrigger EventName="Click">
                <i:Interaction.Behaviors>
                    <ei:ConditionBehavior>
                        <ei:ConditionalExpression>
                            <ei:ComparisonCondition LeftOperand="{Binding IsFocused, RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=Button}}" RightOperand="True"/>
                        </ei:ConditionalExpression>
                    </ei:ConditionBehavior>
                </i:Interaction.Behaviors>
                <ei:ChangePropertyAction TargetObject="{Binding ElementName=Popup1}" PropertyName="IsOpen" Value="True"/>
            </i:EventTrigger>
        </i:Interaction.Triggers>
    </Button>
