        <ListView ItemClick="OnItemClick" SelectionMode="None" IsItemClickEnabled="False">
             ...
                                    <!-- This is the item's info part -->
                                    <StackPanel Orientation="Horizontal" Tapped = "OnItemTapped" Grid.Column="0" >
                                        <TextBlock Text="{Binding Title}" />
                                        <TextBlock Text="{Binding Qnty}" />
                                    </StackPanel>
                                    <!-- This is the change amount part -->
                                    <StackPanel Tag="Oops!" Orientation="Horizontal" Grid.Column="1" >
                                        <Button Content="▲" Tapped = "OnIncreaseTapped"/>
                                        <Button Content="▼" Tapped = "OnDecreaseTapped"/>
                                    </StackPanel>
                                </Grid>
