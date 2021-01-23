    <ControlTemplate.Triggers>
       <MultiTrigger>
          <MultiTrigger.Conditions>
             <Condition Property="IsFocused" Value="False" />
             <Condition Property="Text"  Value="" />
          </MultiTrigger.Conditions>
          <Setter Property="Visibility" TargetName="border" Value="Visible" />
          <Setter Property="Visibility" TargetName="checkmark" Value="Visible" />
       </MultiTrigger>
    </ControlTemplate.Triggers>
