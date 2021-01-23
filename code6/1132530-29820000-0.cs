     <Grid x:Name="MyGrid">
            <FlipView ItemsSource="{Binding Images}">
                <FlipView.ItemTemplate>
                    <DataTemplate>
                        <Grid>
                            <Grid.RowDefinitions>
                                <RowDefinition Height="{Binding ElementName=MyGrid, Path=DataContext.h1}"></RowDefinition>
                                <RowDefinition Height="{Binding ElementName=MyGrid, Path=DataContext.h2}"></RowDefinition>
                            </Grid.RowDefinitions>
                            <Image Grid.Row="0"
                                   Source="{Binding}"></Image>
                            <TextBlock Grid.Row="1"
                                       Text="AAA"></TextBlock>
                        </Grid>
                    </DataTemplate>
                </FlipView.ItemTemplate>
            </FlipView>
        </Grid>
