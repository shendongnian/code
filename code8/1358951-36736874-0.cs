    <ComboBox x:Name="fontFamilyComboBox" SelectedValuePath="Tag">
        <ComboBoxItem Content="Arial">
            <ComboBoxItem.Tag>
                <FontFamily>Arial</FontFamily>
            </ComboBoxItem.Tag>
        </ComboBoxItem>
        <ComboBoxItem Content="Courier">
            <ComboBoxItem.Tag>
                <FontFamily>Courier New</FontFamily>
            </ComboBoxItem.Tag>
        </ComboBoxItem>
    </ComboBox>
    <TextBox Text="Hello, World."
             FontFamily="{Binding SelectedValue, ElementName=fontFamilyComboBox}"/>
