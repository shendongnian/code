    <DataGrid.Resources>
                <Style TargetType="ToolTip">
                    <Setter Property="MaxWidth" Value="20" />
                    <Setter Property="ContentTemplate">
                        <Setter.Value>
                            <DataTemplate>
                                <ContentPresenter Content="{TemplateBinding Content}"  >
                                    <ContentPresenter.Resources>
                                        <Style TargetType="{x:Type TextBlock}">
                                            <Setter Property="TextWrapping" Value="Wrap" />
                                        </Style>
                                    </ContentPresenter.Resources>
                                </ContentPresenter>
                            </DataTemplate>
                        </Setter.Value>
                    </Setter>
                </Style>
            </DataGrid.Resources>
