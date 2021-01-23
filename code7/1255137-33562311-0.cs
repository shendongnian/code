    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition/>
            <ColumnDefinition/>
        </Grid.ColumnDefinitions>
        <Grid.Resources>
            <Style TargetType="telerik:RadListBox" BasedOn="{StaticResource {x:Type telerik:RadListBox}}">
                <Setter Property="BorderThickness" Value="3"/>
                <Style.Triggers>
                    <Trigger Property="IsKeyboardFocusWithin" Value="True">
                        <Setter Property="BorderBrush" Value="Red"/>
                    </Trigger>
                </Style.Triggers>
            </Style>
        </Grid.Resources>
        <telerik:RadListBox Grid.Column="0">
            <telerik:RadListBoxItem Content="1"/>
            <telerik:RadListBoxItem Content="2"/>
            <telerik:RadListBoxItem Content="3"/>
        </telerik:RadListBox>
        <telerik:RadListBox Grid.Column="1">
            <telerik:RadListBoxItem Content="a"/>
            <telerik:RadListBoxItem Content="b"/>
            <telerik:RadListBoxItem Content="c"/>
        </telerik:RadListBox>
    </Grid>
