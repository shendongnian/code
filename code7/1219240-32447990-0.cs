                <GridViewColumn x:Name="fileNameColumn" Width="450" TextBlock.TextAlignment="Left" >
                    <GridViewColumn.Header>
                        <GridViewColumnHeader Content="Filename" Tag="Path">
                            <TextBlock Text="{Binding Path}" HorizontalTextAlignment="Right" FontSize="100"/> <!--This line-->
                        </GridViewColumnHeader>
                    </GridViewColumn.Header>
                </GridViewColumn>
