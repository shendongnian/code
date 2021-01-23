    <Window x:Class="WpfApplication1.MainWindow"
        ...>    
        <Window.Resources>
            <DataTemplate x:Key="SomeTemplate">
                <StackPanel Margin="15">
                    <StackPanel.DataContext>
                        <local:SomeTemplateViewModel />
                    </StackPanel.DataContext>
                    <TextBlock Text="This is some template"/>
                    <Slider Height="30" 
                        IsSnapToTickEnabled="True" 
                        Maximum="100" 
                        SmallChange="1" 
                        IsMoveToPointEnabled="True">
                        <i:Interaction.Triggers>
                            <i:EventTrigger EventName="ValueChanged">
                                <command:EventToCommand 
                            Command="{Binding Mode=OneWay, Path=ValueChangedCommand}"
                            PassEventArgsToCommand="True" />
                            </i:EventTrigger>
                        </i:Interaction.Triggers>
                    </Slider>
                    <TextBlock 
                        Text="{Binding Value}"
                        FontWeight="Bold"
                        FontSize="24">
                    </TextBlock>
                </StackPanel>
            </DataTemplate>
        </Window.Resources>
        <ContentControl 
            DataContext=""
            ContentTemplate="{StaticResource SomeTemplate}" />
    </Window>
