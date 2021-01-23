    <Button x:Name="btn_Kaart2" Grid.Column="1" Grid.Row="2" IsEnabled="False">
        <Button.Template>
            <ControlTemplate>
                <Ellipse x:Name="ellipse_2" 
                    Height="35"
                    Margin="-300,440,0,0"
                    Stroke="Black">
                <Ellipse.Style>
                    <Style TargetType="Ellipse">
                        <Style.Triggers>
                            <DataTrigger Binding="{Binding IsEnabled, RelativeSource={RelativeSource AncestorType=Button}}" Value="false">
                                <Setter Property="Fill" Value="red"></Setter>
                            </DataTrigger>
                            <DataTrigger Binding="{Binding IsEnabled, RelativeSource={RelativeSource AncestorType=Button}}" Value="true">
                                <Setter Property="Fill" Value="green"></Setter>
                            </DataTrigger>
                        </Style.Triggers>
                    </Style>
                </Ellipse.Style>
                </Ellipse>
            </ControlTemplate>
        </Button.Template>
    </Button>
