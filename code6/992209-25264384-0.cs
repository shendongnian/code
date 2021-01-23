    <ListView ItemsSource="{Binding }">
        <ListView.View>
            <GridView AllowsColumnReorder="False" ColumnHeaderToolTip="Employee Information">
                <GridView.ColumnHeaderContainerStyle>
                    <Style TargetType="GridViewColumnHeader">
                        <Setter Property="OverridesDefaultStyle" Value="True" />
                        <Setter Property="Background" Value="Transparent" />
                        <Setter Property="BorderBrush" Value="Black" />
                        <Setter Property="BorderThickness" Value="0,0,0,1" />
                        <Setter Property="Template">
                            <Setter.Value>
                                <ControlTemplate TargetType="GridViewColumnHeader">
                                    <Border BorderThickness="{TemplateBinding BorderThickness}"
                                            BorderBrush="{TemplateBinding BorderBrush}">
                                        <ContentPresenter />
                                    </Border>
                                </ControlTemplate>
                            </Setter.Value>
                        </Setter>
                    </Style>
                </GridView.ColumnHeaderContainerStyle>
                <GridView.Columns>
                    <GridViewColumn Width="100"
                                    DisplayMemberBinding="{Binding Path=LayerName}"
                                    Header="Layer Name" />
                    <GridViewColumn Width="100"
                                    DisplayMemberBinding="{Binding Path=RuleName}"
                                    Header="Rule Name" />
                    <GridViewColumn Width="100"
                                    DisplayMemberBinding="{Binding Path=Action}"
                                    Header="Action" />
                </GridView.Columns>
            </GridView>
        </ListView.View>
    </ListView>
