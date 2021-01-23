       <ListBox x:Name="..."  
                  ItemsSource="{Binding FilteredCollection}"
                  SelectedItem="{Binding SelectedExercise, UpdateSourceTrigger=PropertyChanged}"
                  ...
                  >
            <ListBox.ContextMenu>
                <ContextMenu>
                    <MenuItem Header ="Edit Exercise"	
                              Command="{Binding EditExercise_Command}" 
                              CommandParameter="{Binding SelectedExercise}"
                    />
                    <MenuItem Header ="Delete Exercise" 
                              Command="{Binding DeleteExercise_Command}" 
                              CommandParameter="{Binding SelectedExercise}"
                    />
                </ContextMenu>
            </ListBox.ContextMenu>
    
            <i:Interaction.Triggers>
                <i:EventTrigger EventName="MouseDoubleClick">
                    <Command:EventToCommand Command="{Binding EditExercise_Command}" 
                                            CommandParameter="{Binding ElementName=LastExercises_ListView
                                                                     , Path=SelectedItem}" 
                    />
                </i:EventTrigger>
            </i:Interaction.Triggers>
    
        </ListBox>
