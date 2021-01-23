    <GridView Name="xConcerts" ItemsSource="{x:Bind Artist.UpcomingEvents, Mode=OneWay}">
        <GridView.ItemTemplate>
            <DataTemplate x:DataType="songkick:EventExt">
                <Border CornerRadius="8" Background="{ThemeResource ThemeGrayHighColorBrush}" Opacity="0.8">
                    <StackPanel Margin="18,2">
                        <TextBlock Text="{x:Bind FullDisplayDate, Converter={StaticResource FormatStringToDateDayConverter}}" Style="{ThemeResource ThemeDateBoldStyle}"/>
                        <TextBlock Text="{x:Bind FullDisplayDate, Converter={StaticResource FormatStringToDateMonthConverter}}" Style="{ThemeResource ThemeDateBoldStyle}" Margin="0,-4,0,0"/>
                    </StackPanel>
                </Border>
            </DataTemplate>
        </GridView.ItemTemplate>
        <GridView.ItemContainerTransitions>
            <TransitionCollection>
                <RepositionThemeTransition/>
            </TransitionCollection>
        </GridView.ItemContainerTransitions>
    </GridView>
