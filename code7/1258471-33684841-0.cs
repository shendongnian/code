    <Page ...>
        <Page.Resources>
            <local:MyViewModel x:Key="ViewModel" />
        </Page.Resources>
        ...
        <Border x:Name="BackgroundElement" DataContext="{Binding Source={StaticResource ViewModel}}">
            <Interactivity:Interaction.Behaviors>
                <Core:DataTriggerBehavior Binding="{Binding Tag}" Value="Text">
                    <Core:ChangePropertyAction PropertyName="Background" Value="Red" />
                </Core:DataTriggerBehavior>
            </Interactivity:Interaction.Behaviors>
        </Border>
        ...
    </Page>
