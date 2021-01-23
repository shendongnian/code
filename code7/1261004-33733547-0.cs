    <Window x:Class="SoGridViewHelpAttempt.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:soGridViewHelpAttempt="clr-namespace:SoGridViewHelpAttempt"
        xmlns:system="clr-namespace:System;assembly=mscorlib"
        Title="MainWindow" Height="350" Width="525">
    <Window.Resources>
        <DataTemplate x:Key="ServerNameCellTemplate" DataType="soGridViewHelpAttempt:ServerNameObject">
            <ListBox ItemsSource="{Binding ServerNamePartsCollection}" BorderBrush="#00000000" BorderThickness="2">
                <ListBox.ItemsPanel>
                    <ItemsPanelTemplate>
                        <StackPanel Orientation="Horizontal"></StackPanel>
                    </ItemsPanelTemplate>
                </ListBox.ItemsPanel>
                <ListBox.ItemContainerStyle>
                    <Style TargetType="ListBoxItem">
                        <Setter Property="ContentTemplate">
                            <Setter.Value>
                                <DataTemplate DataType="soGridViewHelpAttempt:ServerNameParts">
                                    <TextBlock IsHitTestVisible="False" Text="{Binding NamePart}" Background="{Binding NamePartBrush}"></TextBlock>
                                </DataTemplate>
                            </Setter.Value>
                        </Setter>
                    </Style>
                </ListBox.ItemContainerStyle>
            </ListBox>
        </DataTemplate>
        <x:Array x:Key="ColorValuePairs" Type="soGridViewHelpAttempt:ColorAndKey">
            <soGridViewHelpAttempt:ColorAndKey Key="^1" Brush="Red"/>
            <soGridViewHelpAttempt:ColorAndKey Key="^2" Brush="Green"/>
            <soGridViewHelpAttempt:ColorAndKey Key="^3" Brush="Blue"/>
        </x:Array>
        <soGridViewHelpAttempt:ServerNameString2ColorNamePartValuesConverter x:Key="ServerNameString2ColorNamePartValuesConverterKey" BrushMap ="{StaticResource ColorValuePairs}"/>
    </Window.Resources>
    <Window.DataContext>
        <soGridViewHelpAttempt:DataGridMAinViewModel/>
    </Window.DataContext>
    <Grid>
        <ListView x:Name="ListView" Margin="0,27,0,0" ItemsSource="{Binding ServerDataCollection}">
            <ListView.View>
                <GridView>
                    <GridViewColumn Header="Server Name">
                        <GridViewColumn.CellTemplate>
                            <DataTemplate DataType="soGridViewHelpAttempt:Server">
                                <ContentControl x:Name="ServerNamePresenter" Content="{Binding ServerName, Converter={StaticResource ServerNameString2ColorNamePartValuesConverterKey}}" ContentTemplate="{StaticResource ServerNameCellTemplate}"></ContentControl>
                            </DataTemplate>
                        </GridViewColumn.CellTemplate>
                    </GridViewColumn>
                    <GridViewColumn Header="Players" DisplayMemberBinding="{Binding Players}"/>
                    <GridViewColumn Header="Map" DisplayMemberBinding="{Binding Map}"/>
                    <GridViewColumn Header="Game Type" DisplayMemberBinding="{Binding GameType}"/>
                    <GridViewColumn Header="Ip" DisplayMemberBinding="{Binding Ip}"/>
                </GridView>
            </ListView.View>
        </ListView>
    </Grid>
