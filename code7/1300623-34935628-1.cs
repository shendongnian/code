    <Grid>
        <Interactivity:Interaction.Behaviors>
            <Core:DataTriggerBehavior Binding="{Binding IsSelected}" Value="True">
                <Core:ChangePropertyAction TargetObject="{Binding ElementName=view1}" PropertyName="Visibility" Value="Visible"/>
                <Core:ChangePropertyAction TargetObject="{Binding ElementName=view2}" PropertyName="Visibility" Value="Collapsed"/>
            </Core:DataTriggerBehavior>
            <Core:DataTriggerBehavior Binding="{Binding IsSelected}" Value="False">
                <Core:ChangePropertyAction TargetObject="{Binding ElementName=view1}" PropertyName="Visibility" Value="Visible"/>
                <Core:ChangePropertyAction TargetObject="{Binding ElementName=view2}" PropertyName="Visibility" Value="Collapsed"/>
            </Core:DataTriggerBehavior>
        </Interactivity:Interaction.Behaviors>
    </Grid>
