            <Style TargetType="Expander" x:Key="ExpanderStyle">
            <Setter Property="Background" Value="{DynamicResource {x:Static SystemColors.ControlDarkBrushKey}}"/>
            <Setter Property="Foreground" Value="{DynamicResource {x:Static SystemColors.ControlTextColor}}"/>
            <Setter Property="Template">
                <Setter.Value>
                    <!-- Control template for expander -->
                    <ControlTemplate TargetType="Expander" x:Name="exp">
                        <Grid>
                            <Grid.RowDefinitions>
                                <RowDefinition Height="Auto"/>
                                <RowDefinition Name="ContentRow" Height="0"/>
                            </Grid.RowDefinitions>
                            <Border Name="border" Grid.Row="0" Background="{TemplateBinding Background}" BorderThickness="1" CornerRadius="4,4,0,0" >
                                <Grid>
                                    <Grid.ColumnDefinitions>
                                        <ColumnDefinition Width="*" />
                                        <ColumnDefinition Width="20" />
                                    </Grid.ColumnDefinitions>
                                    <ToggleButton x:Name="tb" FontFamily="Marlett" FontSize="9.75" Background="{DynamicResource {x:Static SystemColors.ControlDarkBrushKey}}" Foreground="Black" Grid.Column="1" Content="u" IsChecked="{Binding Path=IsExpanded,Mode=TwoWay,RelativeSource={RelativeSource TemplatedParent}}" />
                                    <ContentPresenter x:Name="HeaderContent" Grid.Column="0" Margin="4" ContentSource="Header" RecognizesAccessKey="True" />
                                </Grid>
                            </Border>
                            <Border x:Name="Content" Grid.Row="1" BorderThickness="1,0,1,1" CornerRadius="0,0,4,4" >
                                <ContentPresenter Margin="4" />
                            </Border>
                        </Grid>
                        <ControlTemplate.Triggers>
                            <Trigger Property="IsExpanded" Value="True">
                                <Setter TargetName="ContentRow" Property="Height" Value="{Binding ElementName=Content,Path=Height}" />
                                <Setter Property="Content" TargetName="tb" Value="t"></Setter>
                            </Trigger>
                        </ControlTemplate.Triggers>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
        <Style x:Key="ExpanderStyleRed" BasedOn="{StaticResource ExpanderStyle}" TargetType="Expander">
            <Setter Property="Background" Value="#2fff0000"/>
        </Style>
