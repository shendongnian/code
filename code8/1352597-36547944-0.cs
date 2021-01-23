    <Checkbox x:Name="enablingCheckBox" Content="Enabled?" IsChecked="{Binding IsEnabled}"/>
    <Grid IsEnabled="{Binding IsEnabled, Mode=OneWay, ElementName=enablingCheckBox}">
        <Button Content="Sample"/>
        <ComboBox/>
    </Grid>
