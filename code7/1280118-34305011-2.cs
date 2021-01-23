    <Button>
        <i:Interaction.Triggers>
            <i:EventTrigger EventName="Click">
                <i:Interaction.Behaviors>
                    <ei:ConditionBehavior>
                        <ei:ConditionalExpression>
                            <ei:ComparisonCondition LeftOperand="{Binding IsFocused, RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=Button}}" RightOperand="True"/>
                        </ei:ConditionalExpression>
                    </ei:ConditionBehavior>
                </i:Interaction.Behaviors>
    
                <!-- Store Button's old Background -->
                <ei:ChangePropertyAction TargetObject="{Binding ElementName=Popup1}" PropertyName="Tag" Value="{Binding Background, RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=Button}}"/>
    
                <!-- Change Button's Background -->
                <ei:ChangePropertyAction PropertyName="Background" Value="Purple"/>
    
                <!-- Open Popup -->
                <ei:ChangePropertyAction TargetObject="{Binding ElementName=Popup1}" PropertyName="IsOpen" Value="True"/>
                            
                <!-- Save this Button, Popup will use it to revert back its old Background -->
                <ei:ChangePropertyAction TargetObject="{Binding ElementName=Popup1}" PropertyName="PlacementTarget" Value="{Binding RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=Button}}"/>
                        
            </i:EventTrigger>
        </i:Interaction.Triggers>
    </Button>
    <Popup x:Name="Popup1" Placement="Mouse" StaysOpen="False">
        <i:Interaction.Triggers>
            <i:EventTrigger EventName="Closed">
                <ei:ChangePropertyAction 
                            TargetObject="{Binding PlacementTarget, RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=Popup}}" 
                            PropertyName="Background" 
                            Value="{Binding Tag, RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=Popup}}" />
            </i:EventTrigger>
        </i:Interaction.Triggers>
        <Grid>
            <TextBlock HorizontalAlignment="Center" VerticalAlignment="Center" TextWrapping="Wrap" Text="Welcome to Popup Screen"/>
        </Grid>
    </Popup>    
