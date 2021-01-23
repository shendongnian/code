        <ListView Margin="120,30,0,120" ItemsSource="{Binding MainViewModel}"
          Grid.Row="1">
            <ListView.ItemContainerStyle>
                <Style TargetType="ListViewItem">
                    <Setter Property="Template">
                        <Setter.Value>
                            <ControlTemplate TargetType="ListViewItem">
                                <Grid>
                                    <ContentPresenter HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}"
                                VerticalAlignment="{TemplateBinding VerticalContentAlignment}"
                                SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}" />
                                </Grid>
                            </ControlTemplate>
                        </Setter.Value>
                    </Setter>
                </Style>
            </ListView.ItemContainerStyle>
            <ListView.ItemTemplate>
                <DataTemplate>
                    <Grid Width="500" VerticalAlignment="Center">
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="1*" />
                            <ColumnDefinition Width="1*" />
                            <ColumnDefinition Width="1*" />
                            <ColumnDefinition Width="1*" />
                            <ColumnDefinition Width="1*" />
                            <ColumnDefinition Width="1*" />
                            <ColumnDefinition Width="1*" />
                        </Grid.ColumnDefinitions>
                        <Grid.Resources>
                            <Style TargetType="TextBlock">
                                <Setter Property="Margin" Value="5,0" />
                                <Setter Property="Foreground" Value="White" />
                            </Style>
                            <Style TargetType="Border">
                                <Setter Property="BorderThickness" Value="1" />
                                <Setter Property="BorderBrush" Value="LightGray" />
                                <Setter Property="Background" Value="DarkGray" />
                            </Style>
                        </Grid.Resources>
                        <Border Grid.Column="0" >
                            <TextBlock Text="{Binding Data, Mode=TwoWay}" />
                        </Border>
                        <Border Grid.Column="1" >
                            <TextBlock Text="{Binding Year, Mode=TwoWay}" />
                        </Border>
                        <Border Grid.Column="2" >
                            <TextBlock Text="{Binding Month, Mode=TwoWay}" />
                        </Border>
                        <Border Grid.Column="3" >
                            <TextBlock Text="{Binding Weekday, Mode=TwoWay}" />
                        </Border>
                        <Border Grid.Column="4" >
                            <TextBlock Text="{Binding Day, Mode=TwoWay}" />
                        </Border>
                        <Border Grid.Column="5" >
                            <TextBlock Text="{Binding Data2, Mode=TwoWay}" />
                        </Border>
                        <Border Grid.Column="6" >
                            <TextBlock Text="{Binding Data3, Mode=TwoWay}" />
                        </Border>
                    </Grid>
                </DataTemplate>
            </ListView.ItemTemplate>
            <ListView.Template>
                <ControlTemplate>
                    <Grid HorizontalAlignment="Left">
                        <Grid.RowDefinitions>
                            <RowDefinition Height="Auto"/>
                            <RowDefinition Height="*"/>
                        </Grid.RowDefinitions>
                        <Grid Grid.Row="0" Width="500" VerticalAlignment="Center">
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width="1*" />
                                <ColumnDefinition Width="1*" />
                                <ColumnDefinition Width="1*" />
                                <ColumnDefinition Width="1*" />
                                <ColumnDefinition Width="1*" />
                                <ColumnDefinition Width="1*" />
                                <ColumnDefinition Width="1*" />
                            </Grid.ColumnDefinitions>
                            <Grid.Resources>
                                <Style TargetType="TextBlock">
                                    <Setter Property="Margin" Value="5,0" />
                                    <Setter Property="Foreground" Value="White" />
                                    <Setter Property="FontWeight" Value="Bold" />
                                </Style>
                                <Style TargetType="Border">
                                    <Setter Property="BorderThickness" Value="1" />
                                    <Setter Property="BorderBrush" Value="LightGray" />
                                    <Setter Property="Background" Value="MidnightBlue" />
                                </Style>
                            </Grid.Resources>
                            <Border Grid.Column="0">
                                <TextBlock >Data</TextBlock>
                            </Border>
                            <Border Grid.Column="1">
                                <TextBlock >Year</TextBlock>
                            </Border>
                            <Border Grid.Column="2">
                                <TextBlock >Month</TextBlock>
                            </Border>
                            <Border Grid.Column="3">
                                <TextBlock >Weekday</TextBlock>
                            </Border>
                            <Border Grid.Column="4">
                                <TextBlock >Day</TextBlock>
                            </Border>
                            <Border Grid.Column="5">
                                <TextBlock >Data2</TextBlock>
                            </Border>
                            <Border Grid.Column="6">
                                <TextBlock >Data3</TextBlock>
                            </Border>
                        </Grid>
                        <ItemsPresenter Grid.Row="1"></ItemsPresenter>
                    </Grid>
                </ControlTemplate>
            </ListView.Template>
        </ListView>
