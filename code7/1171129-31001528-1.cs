    <Application 
    ...
             xmlns:Dialogs="clr-namespace:MahApps.Metro.Controls.Dialogs;assembly=MahApps.Metro"
             xmlns:local="clr-namespace:THE_NAMESPASE_OF_BEHAVIOR">
        <Application.Resources>
            <ResourceDictionary>
                <Style TargetType="{x:Type Dialogs:InputDialog}">
                    <Style.Setters>
                        <Setter Property="local:BaseMetroDialogAdjustTextBehavior.IsAttached" Value="True"/>
                    </Style.Setters>
                </Style>
            </ResourceDictionary>
        </Application.Resources>
    </Application>
