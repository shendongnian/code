    <?xml version="1.0" encoding="utf-8" ?>
    <VoiceCommands xmlns="http://schemas.microsoft.com/voicecommands/1.2">
        <CommandSet xml:lang="en-us" Name="FNOW_en-us">
            <AppName> YourAppName </AppName>
            <Example> Search books </Example>
    
            <Command Name="SearchFor">
                <Example> Search for Harry Potter </Example>
                <ListenFor RequireAppName="BeforeOrAfterPhrase"> find book {SearchTerm} </ListenFor>
                <Feedback> Searching books </Feedback>
                <Navigate />
            </Command>
    
            <PhraseTopic Label="SearchTerm" Scenario="Search"/>
        </CommandSet>
    </VoiceCommands>
