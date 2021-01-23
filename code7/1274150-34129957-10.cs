    <Button Content="Options" Command="{Binding OpenConnectionOptionsCommand}">
        <i:Interaction.Triggers>
            <pit:InteractionRequestTrigger SourceObject="{Binding OptionSettingConfirmationRequest, Mode=OneWay}" >
                <pie:LazyPopupWindowAction RegionName="ConnectionSettings" 
                                    NavigationUri="ConnectionSettingsView" IsModal="True" />
            </pit:InteractionRequestTrigger>
        </i:Interaction.Triggers>
    </Button>
