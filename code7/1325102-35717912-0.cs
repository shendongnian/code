    <Button Grid.Column="2" x:Name="btnOpen" Click="btnOpen_Click">
          <Border x:Name="borderBtnOpen" CornerRadius="10" BorderBrush="DarkGray" BorderThickness="1" Background="Transparent">
               <Grid Background="{DynamicResource AccentColorBrush}" Margin="6">
                    <Grid.OpacityMask>
                       <VisualBrush Stretch="Fill" Visual="{DynamicResource appbar_folder}"/>
                    </Grid.OpacityMask>
                    <Grid.ColumnDefinitions>
                      <ColumnDefinition Width="Auto"/>
                      <ColumnDefinition Width="*"/>
                    </Grid.ColumnDefinitions>
                    <Image Grid.Column="0"/>
                    <Textblock Grid.Column="1"/>
               </Grid>
           </Border>
    </Button>
