        <Expander HorizontalAlignment="Stretch" IsExpanded="True">
            <Expander.Header >
                <!-- Width-Binding is needed, to fill the whole header horizontally-->
                <Grid HorizontalAlignment="Stretch" Background="Aqua" Margin="0" Width="{Binding RelativeSource={RelativeSource Mode=FindAncestor, AncestorType={x:Type Expander}}, Path=ActualWidth}">
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="*"/>
                        <ColumnDefinition Width="Auto" />
                    </Grid.ColumnDefinitions>
                    <Label Grid.Column="0" Content="Label on the left site"/>
                    <!-- Margin is needed, to bring the Button into the view -->
                    <Button Grid.Column="1" Content="Button on the right" Margin="0,0,40,0"/>
                </Grid>
            </Expander.Header>
            <Label Content="Some Content"/>
        </Expander>
