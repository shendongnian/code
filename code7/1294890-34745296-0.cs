     <DataGrid  AutoGenerateColumns="False" 
                       ItemsSource="{Binding MobileList, UpdateSourceTrigger=PropertyChanged}" 
                       SelectionUnit="FullRow" IsReadOnly="True" >
    
                <DataGrid.InputBindings>
                    <KeyBinding Key="C" Modifiers="Ctrl" Command="{Binding Path=DataContext.CopyToClipBoardCommand}" CommandParameter="{Binding }" />
                </DataGrid.InputBindings>
                
                <i:Interaction.Triggers>
                    <i:EventTrigger  EventName="CurrentCellChanged">
                        <i:InvokeCommandAction Command="{Binding Path=DataContext.CallCommand,RelativeSource={RelativeSource Mode=FindAncestor,AncestorType={x:Type Window}}}"/>
                    </i:EventTrigger>
                </i:Interaction.Triggers>
                
                <DataGrid.Columns>
                 
                    <!--Column 1-->
                    <DataGridTextColumn Binding="{Binding MobileName}" Header="Name" />
                    <!--Column 2-->
                    <DataGridTextColumn Binding="{Binding MobileOS}" Header="OS" />
                </DataGrid.Columns>
            </DataGrid>
