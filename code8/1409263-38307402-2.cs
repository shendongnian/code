    <ComboBox
        ...other properties...
        SelectedValuePath="Number"
        >
        <ComboBox.SelectedValue>
            <Binding 
                Path="Meeting.BibleReadingMainStudyPoint"
                Mode="TwoWay"
                UpdateSourceTrigger="PropertyChanged"
                >
                <Binding.ValidationRules>
                    <ValidationRules:StudyPointValidationRule BibleReading="True"/>
                </Binding.ValidationRules>
            </Binding> 
        </ComboBox.SelectedValue>
        <ComboBox.Style>
            <Style 
                TargetType="ComboBox" 
                BasedOn="{StaticResource {x:Type ComboBox}}"
                >
                <Style.Triggers>
                    <Trigger Property="Validation.HasError" Value="True">
                        <Setter 
                            Property="ToolTip"
                            Value="{Binding RelativeSource={RelativeSource Self}, Path=(Validation.Errors)[0].ErrorContent}"/>
                    </Trigger>
                </Style.Triggers>
            </Style>
        </ComboBox.Style>
    </ComboBox>
