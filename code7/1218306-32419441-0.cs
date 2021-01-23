    <GridViewColumn Width ="50" Header="GEN" >
        <GridViewColumn.CellTemplate>
             <DataTemplate>
                  <TextBlock Text="{Binding Path=Gen}" Background="{Binding Gen, Converter={StaticResource BackgroundConverter}}" />
             </DataTemplate>
        </GridViewColumn.CellTemplate>
    </GridViewColumn>
