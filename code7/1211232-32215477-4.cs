     <SearchBar x:Name="searchBar"
           Text=""
           Placeholder="type something">
        <SearchBar.Triggers>
        
            <DataTrigger TargetType="SearchBar"
                         Binding="{Binding ViewModelIsSearchBarFocused}"
                         Value="True">
                         
                <Trigger.EnterActions>
                    <local:FocusTriggerAction Focused="True" />
                </Trigger.EnterActions>
                
                <Trigger.ExitActions>
                    <local:FocusTriggerAction Focused="False" />
                </Trigger.ExitActions>
                
            </DataTrigger>   
            
            <EventTrigger Event="Unfocused">
                <local:UnfocusedTriggerAction />
            </EventTrigger>    
            
        </SearchBar.Triggers>       
    </SearchBar>
