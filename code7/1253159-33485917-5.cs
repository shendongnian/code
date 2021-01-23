    <Style x:Key="ListViewItemStyle1" TargetType="{x:Type ListViewItem}">
            <Setter Property="IsSelected" Value="{Binding IsSelected}"/>
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="{x:Type ListViewItem}">
                        <Grid x:Name="Bd">
                            <ContentPresenter  />
                        </Grid>
                        <ControlTemplate.Triggers>
                            <MultiTrigger>
                                <MultiTrigger.Conditions>
                                    <Condition Property="IsSelected" Value="True"/>
                                </MultiTrigger.Conditions>
                                <Setter Property="Background" TargetName="Bd" Value="#FF204080"/>
                            </MultiTrigger>
                        </ControlTemplate.Triggers>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
