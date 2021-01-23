    <TextBox Name="VehicalNo_Text">
        <TextBox.Text>
            <Binding Path="VehicleNo" UpdateSourceTrigger="LostFocus">
                <Binding.ValidationRules>
                    <ExceptionValidationRule />
                </Binding.ValidationRules>
            </Binding>
        </TextBox.Text>
    </TextBox>
