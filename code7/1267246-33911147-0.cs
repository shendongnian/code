    <ComboBox ItemsSource="{Binding TempCollection}">
                <ComboBox.ItemTemplate>
                    <DataTemplate>
                        <Label Content="{Binding Converter={StaticResource TempConverter}}"/>
                    </DataTemplate>
                </ComboBox.ItemTemplate>
                <ComboBox.ItemContainerStyle>
                    <Style TargetType="{x:Type ComboBoxItem}">
                        <Setter Property="Template">
                            <Setter.Value>
                                <ControlTemplate TargetType="{x:Type ComboBoxItem}">
                                    <Border
                                    BorderBrush="{TemplateBinding BorderBrush}"
                                    BorderThickness="{TemplateBinding BorderThickness}"
                                    Background="{TemplateBinding Background}">
                                        <StackPanel Orientation="Horizontal">
                                            <ContentPresenter HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" 
                                                              VerticalAlignment="{TemplateBinding VerticalContentAlignment}" />
                                        </StackPanel>
                                    </Border>
                                </ControlTemplate>
                            </Setter.Value>
                        </Setter>
                    </Style>
                </ComboBox.ItemContainerStyle>
            </ComboBox>
