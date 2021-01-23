          <Grid>
        <Grid.Resources>
            <ObjectDataProvider 
    ObjectInstance="{x:Type Colors}" 
    MethodName="GetProperties" 
    x:Key="colorPropertiesOdp"  />
            
            <Style TargetType="{x:Type HeaderedContentControl}">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="{x:Type HeaderedContentControl}">
                            <Grid>
                                <Grid.ColumnDefinitions>
                                    <ColumnDefinition />
                                    <ColumnDefinition />
                                </Grid.ColumnDefinitions>
                                <ContentPresenter ContentSource="Content" />
                                <ContentPresenter ContentSource="Header" Grid.Column="1" VerticalAlignment="Center"/>
                            </Grid>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </Grid.Resources>
        <ComboBox ItemsSource="{Binding Source={StaticResource colorPropertiesOdp}}" Height="23" HorizontalAlignment="Right" Name="comboBox_PC_Opt" VerticalAlignment="Top" Width="130" 
                  >
            <ComboBox.ItemTemplate>
                <DataTemplate DataType="{x:Type Color}">
                    <HeaderedContentControl Header="{Binding Path=Name}">
                        <Rectangle Fill="{Binding Path=Name}" Width="15" Height="15" Margin="0,2,5,2" />
                    </HeaderedContentControl>
                </DataTemplate>
            </ComboBox.ItemTemplate>
        </ComboBox>
    </Grid>
