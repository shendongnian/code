    <Grid>
            <Grid.RowDefinitions>
             <RowDefinition Height="50"/>
              <RowDefinition Height="500"/>
            </Grid.RowDefinitions>
       
        <StackPanel Grid.Row="0" Orientation="Horizontal" Background="Red"  >
            <TextBox Height="50" Width="250">t1</TextBox>
            <Slider></Slider>
            <TextBox>t2</TextBox>
        </StackPanel>
       <Grid Grid.Row="1">
        <DataGrid   Name="DGComm" AutoGenerateColumns="False" CanUserResizeColumns="True" IsReadOnly="True" ItemsSource="{Binding LogMessagesList}">
            <DataGrid.Columns>
                <DataGridTextColumn Header="Time Stamp." Binding="{Binding Date, StringFormat='{}{0:yyyy-MM-dd HH:mm:ss,fff}'}"  Width="0.1*"/>  
                  </DataGrid.Columns>
        </DataGrid>
        </Grid>
        
         </Grid>
