    <ItemsControl ItemsSource="{Binding}">
                <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <Grid>
                            <TextBlock x:Name="myTextBlock" Text="{Binding Name}" />
                            <Slider IsEnabled="{Binding Audible}" Value="{Binding Volume}" />
                            <Slider IsEnabled="{Binding Audible}"  Value="{Binding Pan}" />
                    </Grid>
                    <DataTemplate.Triggers>
                            <DataTrigger Binding="{Binding UserIsSpeaking}" Value="True">
                                <Setter TargetName="myTextBlock" Property="Background" Value="Lime"></Setter>
                            </DataTrigger>
                     </DataTemplate.Triggers>
                </DataTemplate>
            </ItemsControl.ItemTemplate>
    </ItemsControl>
