    <ComboBox DataContext="{Binding DataContext, ElementName=oclmEditor}"
                  ItemsSource="{Binding ReadingStudyPointsList}">
        <ComboBox.ItemContainerStyle>
            <Style TargetType="ComboBoxItem">
                <Setter Property="Tag" Value="{Binding Number}" />
                <Style.Triggers>
                    <DataTrigger Value="True">
                        <DataTrigger.Binding>
                            <MultiBinding Converter="{StaticResource StudyPointWorkingOn}">
                                <Binding RelativeSource="{RelativeSource Self}" Path="Tag"/>
                                <Binding Path="DataContext.SelectedStudentItem" ElementName="oclmEditor" UpdateSourceTrigger="PropertyChanged" />
                            </MultiBinding>
                        </DataTrigger.Binding>
                        <Setter Property="Background" Value="Red"/>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </ComboBox.ItemContainerStyle>
        <ComboBox.ItemTemplate>
            <DataTemplate>
                <StackPanel Orientation="Horizontal">
                    <TextBlock Text="{Binding Number}"/>
                    <TextBlock Text=" - "/>
                    <TextBlock Text="{Binding Title}"/>
                </StackPanel>
            </DataTemplate>
        </ComboBox.ItemTemplate>
    </ComboBox>
