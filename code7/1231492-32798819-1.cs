        <DataGridTemplateColumn Width ="60" HeaderStyle="{StaticResource HeaderStyle}" Header="Selected" >
            <DataGridTemplateColumn.CellTemplate>
              <DataTemplate>
                <Grid IsEnabled={Binding StepTaskViewInfo.AreStepsTasksReadonly}
                  <CheckBox  VerticalAlignment="Center" HorizontalAlignment="Center"  
    IsChecked="{Binding  IsSelected,UpdateSourceTrigger=PropertyChanged}" 
                     IsEnabled="{Binding IsTaskEnabled,UpdateSourceTrigger=PropertyChanged}"  />
                </Grid>
              </DataTemplate>
           </DataGridTemplateColumn.CellTemplate>
        </DataGridTemplateColumn>
