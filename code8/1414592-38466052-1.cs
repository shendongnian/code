       <Button Content="Click me" Width="80" Height="20" Command="{Binding CreateButtonCommand}">
                    <Button.Template>
                        <ControlTemplate TargetType="Button">
                            <Grid>
                                <Grid.ColumnDefinitions>
                                    <ColumnDefinition Width="Auto"></ColumnDefinition>
                                    <ColumnDefinition Width="*"></ColumnDefinition>
                                </Grid.ColumnDefinitions>
    
                                <CheckBox Content="{Binding Path=Name}" Grid.Column="0" IsHitTestVisible="false" IsChecked="{Binding Path=IsChecked, Mode=OneWay}"/>
                                <ContentPresenter Grid.Column="1">
                                </ContentPresenter>
                                <Rectangle Fill="Transparent" Opacity="1" Width="{TemplateBinding Width}" Height="{TemplateBinding Height}" Grid.ColumnSpan="2">
                                    <Rectangle.InputBindings>
                                        <MouseBinding Command="{TemplateBinding Command}"></MouseBinding>
                                    </Rectangle.InputBindings>
                                </Rectangle>
                            </Grid>
                        </ControlTemplate>
                    </Button.Template>
                </Button>
