     <GridView x:Name="ItemGridView"   
                  ItemsSource="{Binding Source={StaticResource ItemsViewSource}}" 
                  IsItemClickEnabled="True" 
                  SelectionMode="Single" ItemClick="ItemGridView_ItemClick" 
                  SelectionChanged="ItemGridView_SelectionChanged">
            <GridView.ItemTemplate>
                <DataTemplate>
                    <Grid RightTapped="Grid_RightTapped">
                        <Border Background="White"  BorderThickness="0" Width="210" Height="85">
                            <TextBlock Text="{Binding FileName}" />
                        </Border>
                    </Grid>
                </DataTemplate>
            </GridView.ItemTemplate>
        </GridView>
