    <Window.Resources>
        <DataTemplate x:Key="DataTemplate1">
            <Grid Width="200" Background="Lime">
                <TextBlock Text="{Binding}" Foreground="Black"/>
            </Grid>
        </DataTemplate>
        <DataTemplate x:Key="DataTemplate2">
            <Grid Width="200" Background="DarkGray">
                <TextBlock Text="{Binding}" Foreground="Black"/>
            </Grid>
        </DataTemplate>
        <DataTemplate x:Key="DataTemplate1Sel">
            <Grid Width="200" Background="Coral">
                <TextBlock Text="{Binding}" Foreground="Black"/>
            </Grid>
        </DataTemplate>
    </Window.Resources>
    <ListBox x:Name="Lst" Margin="0,56,10,0">
        <ListBox.Resources>
            <Style TargetType="ListBoxItem">
                <Style.Triggers>
                    <Trigger Property="IsSelected" Value="True">
                        <Setter Property="ContentTemplate" Value="{DynamicResource DataTemplate1Sel}"/>
                    </Trigger>
                    <Trigger Property="IsSelected" Value="False">
                        <Setter Property="ContentTemplate" Value="{DynamicResource DataTemplate1}"/>
                    </Trigger>
                    <MultiDataTrigger>
                        <MultiDataTrigger.Conditions>
                            <Condition  Binding="{Binding IsActive, RelativeSource={RelativeSource AncestorType=Window, Mode=FindAncestor}}" Value="False"/>
                            <Condition  Binding="{Binding IsSelected, RelativeSource={RelativeSource Self}}" Value="True"/>
                        </MultiDataTrigger.Conditions>
                        <MultiDataTrigger.Setters>
                            <Setter Property="ContentTemplate" Value="{DynamicResource DataTemplate2}"/>
                        </MultiDataTrigger.Setters>
                    </MultiDataTrigger>
                </Style.Triggers>
            </Style>
        </ListBox.Resources>
    </ListBox>
