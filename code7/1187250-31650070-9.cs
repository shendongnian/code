        <ListView ItemClick="OnItemClick">
            <ListView.ItemContainerStyle>
                <Style TargetType="ListViewItem">
                    <Setter Property="Template">
                        <Setter.Value>
                            <ControlTemplate TargetType="ListViewItem">
                                <Grid>
                                    <Grid.ColumnDefinitions>
                                        <ColumnDefinition Width="*"/>
                                        <ColumnDefinition Width="100"/>
                                    </Grid.ColumnDefinitions>
                                    <!-- This is the item's info part -->
                                    <StackPanel Orientation="Horizontal" Grid.Column="0" >
                                        <TextBlock Text="{Binding Title}" />
                                        <TextBlock Text="{Binding Qnty}" />
                                    </StackPanel>
                                    <!-- This is the change amount part -->
                                    <StackPanel Tag="Oops!" Orientation="Horizontal" Grid.Column="1" >
                                        <Button Content="▲" />
                                        <Button Content="▼" />
                                    </StackPanel>
                                </Grid>
                            </ControlTemplate>
                        </Setter.Value>
                    </Setter>
                </Style>
            </ListView.ItemContainerStyle>
        </ListView>
