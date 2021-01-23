    <Button.Style>
          <Style TargetType="{x:Type Button}">
              <Style.Triggers>
                  <MultiDataTrigger>
                         <MultiDataTrigger.Conditions>
                            <Condition Binding="{Binding ElementName=firstTxtBox, Path=Text.Length, Mode=OneWay}" Value="0"/>
                            <Condition Binding="{Binding ElementName=lastTxtBox, Path=Text.Length, Mode=OneWay}" Value="0"/>
                        </MultiDataTrigger.Conditions>
                        <Setter Property="IsEnabled" Value="False"/>
                 </MultiDataTrigger>
             </Style.Triggers>
          </Style>
    </Button.Style>
