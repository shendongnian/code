    <ListView
       Background="#f0f0f0" 
       Grid.Row="1" 
       ItemsSource="{Binding ListViewCollection}" 
       Name="ListView" 
       IsSynchronizedWithCurrentItem="True" 
       BorderThickness="0" 
       Margin="5">
       <ListView.View>
          <GridView>
             <GridView.Columns>
                <GridViewColumn>
                   <GridViewColumn.CellTemplate>
                      <DataTemplate>
                          <CheckBox IsChecked="{Binding IsChecked}" 
    					  Command="{Binding ElementName=ListView,Path=DataContext.HideShowGraph}" 
    					  CommandParameter="{Binding TheValue, Mode=OneWay}" />
                      </DataTemplate>
                   </GridViewColumn.CellTemplate>
                </GridViewColumn>
                <GridViewColumn DisplayMemberBinding="{Binding TheText}" Header="#Cell" />
                <GridViewColumn DisplayMemberBinding="{Binding TheVoltage}" Header="U[V]" />
             </GridView.Columns>
          </GridView>
       </ListView.View>
    </ListView>
