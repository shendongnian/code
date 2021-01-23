    <Button ToolTip="{Binding ButtonLabel,RelativeSource={RelativeSource AncestorType=UserControl,Mode=FindAncestor},UpdateSourceTrigger=PropertyChanged}" 
                    Command="{Binding ButtonCommand,RelativeSource={RelativeSource AncestorType=UserControl,Mode=FindAncestor},UpdateSourceTrigger=PropertyChanged}"
                    Cursor="Hand" VerticalAlignment="Center" >
                <Button.Template>
                    <ControlTemplate>
                        <Grid>
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width="45"/>
                                <ColumnDefinition Width="*"/>
                            </Grid.ColumnDefinitions>
                            <Image Name="ButtonImage" IsEnabled="{Binding Path=IsEnabled,RelativeSource={RelativeSource AncestorType=Button,Mode=FindAncestor}}"  >
                                <Image.Style>
                                    <Style TargetType="{x:Type Image}">
                                        <Style.Triggers>
                                            <Trigger Property="IsEnabled" Value="True">
                                                <Setter Property="Source" Value="{Binding ActiveImage,RelativeSource={RelativeSource AncestorType=UserControl,Mode=FindAncestor},UpdateSourceTrigger=PropertyChanged}"/>
                                            </Trigger>
                                            <Trigger Property="IsEnabled" Value="False">
                                                <Setter Property="Source" Value="{Binding DeactiveImage,RelativeSource={RelativeSource AncestorType=UserControl,Mode=FindAncestor},UpdateSourceTrigger=PropertyChanged}"/>
                                            </Trigger>
                                        </Style.Triggers>
                                    </Style>
                                </Image.Style>
                            </Image>
                            <Label Name="LabelContent" Content="{Binding ButtonLabel,RelativeSource={RelativeSource AncestorType=UserControl,Mode=FindAncestor},UpdateSourceTrigger=PropertyChanged}" 
                           Grid.Column="1" IsEnabled="{Binding Path=IsEnabled,RelativeSource={RelativeSource AncestorType=Button,Mode=FindAncestor}}" VerticalContentAlignment="Center"  />
                        </Grid>
                    </ControlTemplate>
                </Button.Template>
            </Button> 
