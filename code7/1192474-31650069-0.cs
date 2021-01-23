    <ListView ItemsSource="{Binding DelegateUsers}" SelectedItem="{Binding SelectedItem}">
    <i:Interaction.Triggers>
      <i:EventTrigger EventName="MouseDoubleClick">
         <i:InvokeCommandAction Command="{Binding CommandDoubleClick}"/>
      </i:EventTrigger>  
    </i:Interaction.Triggers>
      <ListView.View>
                    <GridView>
                        <GridViewColumn Width="Auto">
                            <GridViewColumnHeader Content="Header1">
                                
                            </GridViewColumnHeader>
