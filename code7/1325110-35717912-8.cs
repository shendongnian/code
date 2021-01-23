    <Button Grid.Column="2" x:Name="btnOpen" Click="btnOpen_Click">
          <Border x:Name="borderBtnOpen" CornerRadius="10" BorderBrush="DarkGray" BorderThickness="1" Background="Transparent">
               <Grid Background="{DynamicResource AccentColorBrush}" Margin="6">
                    <Grid.ColumnDefinitions>
                      <ColumnDefinition Width="Auto"/>
                      <ColumnDefinition Width="*"/>
                    </Grid.ColumnDefinitions>
                    <Rectangle Grid.Column="0">
                        <Rectangle.Fill>
                            <VisualBrush Stretch="Fill" Visual="{DynamicResource appbar_folder}"/>
                        </Rectangle.Fill>
                    </Rectangle>
                    <Textblock Grid.Column="1"/>
               </Grid>
           </Border>
    </Button>
