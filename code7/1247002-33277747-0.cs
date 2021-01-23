    <Window x:Class="SoDataGridProjectsHelpAttempt.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:soDataGridProjectsHelpAttempt="clr-namespace:SoDataGridProjectsHelpAttempt"
        Title="MainWindow" Height="350" Width="525">
    <Grid>
        <ContentControl >
            <ContentControl.ContentTemplate>
                <DataTemplate>
                    <Grid>
                        <soDataGridProjectsHelpAttempt:MainSubControl x:Name="MainSubControl" Visibility="Visible"/>
                        <soDataGridProjectsHelpAttempt:SubSubControl x:Name="SubSubControl" Visibility="Collapsed"/>
                    </Grid>
                    <DataTemplate.Triggers>
                        <Trigger Property="Control.Visibility" Value="Collapsed" SourceName="MainSubControl">
                            <Setter TargetName="SubSubControl" Property="Visibility" Value="Visible"></Setter>
                        </Trigger>
                    </DataTemplate.Triggers>
                </DataTemplate>
            </ContentControl.ContentTemplate>
        </ContentControl>
    </Grid>
