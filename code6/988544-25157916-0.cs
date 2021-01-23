    <ComboBox xmlns:sys="clr-namespace:System;assembly=mscorlib">
        <ComboBox.Resources>
            <Style TargetType="ComboBoxItem">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="ComboBoxItem">
                            <CheckBox>
                                <ContentPresenter />
                            </CheckBox>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </ComboBox.Resources>
        <sys:String>item 1</sys:String>
        <sys:String>item 2</sys:String>
        <sys:String>item 3</sys:String>
        <sys:String>item 4</sys:String>
    </ComboBox>
