    <Style TargetType="{x:Type local:LineControl}">
    <Setter Property="Template">
        <Setter.Value>
            <ControlTemplate TargetType="{x:Type local:LineControl}">
                <Border Background="{TemplateBinding Background}"
                        BorderBrush="{TemplateBinding BorderBrush}"
                        BorderThickness="{TemplateBinding BorderThickness}">
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition></ColumnDefinition>
                            <ColumnDefinition Width="Auto"></ColumnDefinition>
                            <ColumnDefinition></ColumnDefinition>
                        </Grid.ColumnDefinitions>
                        <Separator Grid.Column="0" VerticalAlignment="Center"></Separator>
                        <ContentPresenter Grid.Column="1" Content="{TemplateBinding Content}" VerticalAlignment="Center"></ContentPresenter>
                        <Separator Grid.Column="2" VerticalAlignment="Center"></Separator>
                    </Grid>
                </Border>
            </ControlTemplate>
        </Setter.Value>
    </Setter>
