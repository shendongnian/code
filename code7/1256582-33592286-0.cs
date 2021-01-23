    <ListView x:Name="ImageList" Width="210" Height="210">
        <ListView.View>
           <GridView>
              <GridView.ColumnHeaderContainerStyle>
                <Style TargetType="Control">
                    <Setter Property="Visibility" Value="Collapsed"/>
                </Style>
              </GridView.ColumnHeaderContainerStyle>
              <GridViewColumn>                            
                 <GridViewColumn.CellTemplate>
                      <DataTemplate>
                           <Image Source="{Binding sq1}"/>
                      </DataTemplate>
                 </GridViewColumn.CellTemplate>
               </GridViewColumn>
               <GridViewColumn >
                 <GridViewColumn.CellTemplate>
                       <DataTemplate>
                           <Image Source="{Binding sq2}"/>
                       </DataTemplate>
                  </GridViewColumn.CellTemplate>
                </GridViewColumn>
    
                <GridViewColumn >
                    <GridViewColumn.CellTemplate>
                         <DataTemplate>
                             <Image Source="{Binding sq3}"/>
                         </DataTemplate>
                     </GridViewColumn.CellTemplate>
                 </GridViewColumn>    
           </GridView>
      </ListView.View>
