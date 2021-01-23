    <Button Content="Save" IsDefault="True" Command="{Binding SaveCommand} Width="150" Height="40">
        <Button.Style>
            <Style TargetType="Button">
              <Setter Property="IsEnabled" Value="False"/>
              <Style.Triggers>
                <MultiDataTrigger>
                  <MultiDataTrigger.Conditions>
                    <Condition Binding="{Binding Path=(Validation.HasError), ElementName=PersonName}" Value="False"/>
                  </MultiDataTrigger.Conditions>
                  <Setter Property="IsEnabled" Value="True"/>
                </MultiDataTrigger>
                </Style.Triggers>
              </Style>
        </Button.Style>
    </Button>
