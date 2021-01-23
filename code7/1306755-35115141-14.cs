    <Window.Resources>
        <converter:WorkerToColorMultiConverter x:Key="WorkerToColorMultiConverter" />
    </Window.Resources>
....
    
    <DataGridTextColumn Header="1" Binding="{Binding Col1}">
         <DataGridTextColumn.ElementStyle>
              <Style TargetType="{x:Type TextBlock}">
                   <Setter Property="Background">
                        <Setter.Value>
                             <MultiBinding Converter="{StaticResource WorkerToColorMultiConverter}">
                                  <Binding Path="Col1" />
                                  <Binding Path="Worker" />
                             </MultiBinding>
                         </Setter.Value>
                   </Setter>
               </Style>
           </DataGridTextColumn.ElementStyle>
       </DataGridTextColumn>
       <DataGridTextColumn Header="2" Binding="{Binding Col2}">
            <DataGridTextColumn.ElementStyle>
                 <Style TargetType="{x:Type TextBlock}">
                      <Setter Property="Background">
                           <Setter.Value>
                                <MultiBinding Converter="{StaticResource WorkerToColorMultiConverter}">
                                     <Binding Path="Col2" />
                                     <Binding Path="Worker" />
                                </MultiBinding>
                            </Setter.Value>
                        </Setter>
                    </Style>
                </DataGridTextColumn.ElementStyle>
            </DataGridTextColumn>
