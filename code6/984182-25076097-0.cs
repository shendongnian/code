                   <StackPanel  Grid.Column="1"  Margin="7,-72,7.5,0">
                         <telerik:RadCartesianChart Palette="Summer" >
                              <telerik:RadCartesianChart.HorizontalAxis>
                                 <telerik:CategoricalAxis Visibility="Hidden"/>
                            </telerik:RadCartesianChart.HorizontalAxis>
                            <telerik:RadCartesianChart.VerticalAxis>
                             <telerik:LinearAxis Visibility="Hidden" MajorStep="20" />
                        </telerik:RadCartesianChart.VerticalAxis>
                        <telerik:RadCartesianChart.Series>
                            <telerik:BarSeries ItemsSource="{Binding KeyValue, Mode=TwoWay}" CategoryBinding="Key" ValueBinding="Value">
                                <telerik:BarSeries.PointTemplates>
                                    <DataTemplate>
                                        <Rectangle Width="3" Fill="SkyBlue"/>
                                    </DataTemplate>
                                </telerik:BarSeries.PointTemplates>
                            </telerik:BarSeries>
                        </telerik:RadCartesianChart.Series>
                    </telerik:RadCartesianChart>
                </StackPanel>
                
               <telerik:RadSlider Minimum="{Binding LowValue,Mode=TwoWay}"  Height="13" 
                Margin="5" Grid.Column="1" Maximum="{Binding HighValue,Mode=TwoWay}" 
                SelectionEnd="{Binding SelectionHigh,Mode=TwoWay}" 
                SelectionStart="  {Binding SelectionLow,Mode=TwoWay}"
                TickPlacement="TopLeft"  
                SelectionChanged="RadSlider_SelectionChanged" SelectionRangeEnabled="True" 
                IsDirectionReversed="False" SmallChange="10" VerticalAlignment="Bottom">                        
                 </telerik:RadSlider>
