    <Style TargetType="TextBox" x:Key="FieldTextBoxStyle" BasedOn="{StaticResource FieldTextBoxStyle2}">
    <Setter Property="Template">
      <Setter.Value>
        <ControlTemplate TargetType="TextBox">
          <Grid x:Name="RootElement">
            <Border x:Name="Border" BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" Background="{TemplateBinding Background}" Opacity="1">
              <Grid>
                <Border x:Name="ReadOnlyVisualElement" Background="{StaticResource TextBoxReadOnlyBackgroundBrush}" Opacity="0" />
                <ScrollViewer x:Name="PART_ContentHost" BorderThickness="0" IsTabStop="False" Padding="{TemplateBinding Padding}" />
              </Grid>
            </Border>
            <Border x:Name="DisabledVisualElement" BorderBrush="{StaticResource DisabledVisualElement}" BorderThickness="{TemplateBinding BorderThickness}" Background="{StaticResource DisabledVisualElement}" IsHitTestVisible="False" Opacity="0" />
            <Border x:Name="FocusVisualElement" BorderBrush="{StaticResource TextBoxFocusedBrush}" BorderThickness="{TemplateBinding BorderThickness}" IsHitTestVisible="False" Opacity="0" />
            <Border x:Name="ValidationErrorElement" BorderBrush="{StaticResource ValidationErrorElement}" BorderThickness="{TemplateBinding BorderThickness}" Visibility="Collapsed">
              <ToolTipService.ToolTip>
                <ToolTip x:Name="validationTooltip" DataContext="{Binding RelativeSource={RelativeSource TemplatedParent}}" IsHitTestVisible="true" Placement="Right" PlacementTarget="{Binding RelativeSource={RelativeSource TemplatedParent}}" Template="{StaticResource ValidationToolTipTemplate}"/>
              </ToolTipService.ToolTip>
            </Border>
          </Grid>
          <ControlTemplate.Triggers>
            <MultiTrigger>
              <MultiTrigger.Conditions>
                <Condition Property="IsEnabled" Value="true" />
                <Condition Property="IsMouseOver" Value="true" />
              </MultiTrigger.Conditions>
              <Setter TargetName="Border" Property="BorderBrush" Value="{StaticResource TextBoxHoverBorderBrush}" />
              <Setter TargetName="Border" Property="Background" Value="{StaticResource TextBoxHoverBackgroundBrush}" />
            </MultiTrigger>
            <Trigger Property="IsEnabled" Value="false">
              <Setter TargetName="DisabledVisualElement" Property="Opacity" Value="1" />
            </Trigger>
            <Trigger Property="IsReadOnly" Value="true">
              <Setter TargetName="ReadOnlyVisualElement" Property="Opacity" Value="1" />
            </Trigger>
            <Trigger Property="IsFocused" Value="true">
              <Setter TargetName="FocusVisualElement" Property="Opacity" Value="1" />
            </Trigger>
            <MultiTrigger>
              <MultiTrigger.Conditions>
                <Condition Property="IsFocused" Value="true" />
                <Condition Property="Validation.HasError" Value="true" />
              </MultiTrigger.Conditions>
              <Setter TargetName="ValidationErrorElement" Property="Visibility" Value="Visible" />
              <Setter TargetName="validationTooltip" Property="IsOpen" Value="true" />
            </MultiTrigger>
            <MultiTrigger>
              <MultiTrigger.Conditions>
                <Condition Property="IsFocused" Value="false" />
                <Condition Property="Validation.HasError" Value="true" />
              </MultiTrigger.Conditions>
              <Setter TargetName="ValidationErrorElement" Property="Visibility" Value="Visible" />
            </MultiTrigger>
          </ControlTemplate.Triggers>
        </ControlTemplate>
      </Setter.Value>
    </Setter>
