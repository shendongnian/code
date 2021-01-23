    <UserControl.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="pack://application:,,,/../Controls/LoadingOverlay.xaml"/>
            </ResourceDictionary.MergedDictionaries>
            <Style TargetType="controls:LoadingOverlay">
                <Style.Triggers>
                    <DataTrigger Binding="{Binding Path=RefreshNotifyTask.IsCompleted}" Value="True">
                        <Setter Property="Visibility" Value="Hidden"/>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </ResourceDictionary>
    </UserControl.Resources>
    <controls:LoadingOverlay>
        <StackPanel Orientation="Horizontal" HorizontalAlignment="Center" VerticalAlignment="Center">
            <TextBlock Foreground="White" FontSize="20" Text="Artikelen vernieuwen ..." />
            <Button x:Name="Cancel" Content="Annuleren"/>
        </StackPanel>
    </controls:LoadingOverlay>
