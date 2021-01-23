    <Window x:Class="SimpleDataGrid.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:simpleDataGrid="clr-namespace:SimpleDataGrid"
        Title="MainWindow" Height="350" Width="525" x:Name=This>
    <Window.DataContext>
        <simpleDataGrid:GridViewModel/>
    </Window.DataContext>
    <Grid >
        <DataGrid x:Name="SelectDataGrid" ItemsSource="{Binding ElementName=This, Path=Persons}" HorizontalAlignment="Left" VerticalAlignment="Top" AutoGenerateColumns="False">
            <DataGrid.Columns>
                <DataGridCheckBoxColumn x:Name="dgCheckBox" Header="Select" Width="45" Binding="{Binding IsChecked}"/>
                <DataGridTextColumn Header="FIRST NAME" Width="125" Binding="{Binding FNAME}"/>
                <DataGridTextColumn Header="LAST NAME" Width="125" Binding="{Binding LNAME}"/>
                <DataGridComboBoxColumn Header="Servers"
                                        DisplayMemberPath="ServerName" SelectedValueBinding="{Binding SelectedServer, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}">
                    <DataGridComboBoxColumn.ElementStyle>
                        <Style TargetType="ComboBox">
                            <Setter Property="ItemsSource" Value="{Binding RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type DataGridCell}}, Path=DataContext.Servers}"/>
                            <Setter Property="IsReadOnly" Value="True"/>
                        </Style>
                    </DataGridComboBoxColumn.ElementStyle>
                    <DataGridComboBoxColumn.EditingElementStyle>
                        <Style TargetType="ComboBox">
                            <Setter Property="ItemsSource" Value="{Binding RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type DataGridCell}}, Path=DataContext.Servers}"/>
                        </Style>
                    </DataGridComboBoxColumn.EditingElementStyle>
                </DataGridComboBoxColumn>
                <DataGridComboBoxColumn Header="Dbs" 
                                        DisplayMemberPath="DbName" 
                                        SelectedValueBinding="{Binding SelectedDb, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}">
                    <DataGridComboBoxColumn.ElementStyle>
                        <Style TargetType="ComboBox">
                            <Setter Property="ItemsSource" Value="{Binding RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type DataGridCell}}, Path=DataContext.Dbs}"/>
                            <Setter Property="IsReadOnly" Value="True"/>
                        </Style>
                    </DataGridComboBoxColumn.ElementStyle>
                    <DataGridComboBoxColumn.EditingElementStyle>
                        <Style TargetType="ComboBox">
                            <Setter Property="ItemsSource" Value="{Binding RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type DataGridCell}}, Path=DataContext.Dbs}"/>
                        </Style>
                    </DataGridComboBoxColumn.EditingElementStyle>
                </DataGridComboBoxColumn>
            </DataGrid.Columns>
        </DataGrid>
    </Grid></Window>
