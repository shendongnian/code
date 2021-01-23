    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition/>
            <ColumnDefinition/>
            <ColumnDefinition/>
        </Grid.ColumnDefinitions>
        <RadioButton IsChecked="True" GroupName="HeaderButtons" Template="{StaticResource StaticHeaderRadioButton}">
            Main
        </RadioButton>
        <RadioButton Grid.Column="1" GroupName="HeaderButtons" Template="{StaticResource StaticHeaderRadioButton}">
            view
        </RadioButton>
        <RadioButton Grid.Column="2" GroupName="HeaderButtons" Template="{StaticResource StaticHeaderRadioButton}">
            features
        </RadioButton>
    </Grid>
