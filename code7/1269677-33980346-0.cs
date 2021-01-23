    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="*"/>
            <RowDefinition Height="*"/>
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>
        <TreeView Grid.Row="0" x:Name="TrV">
            <TreeViewItem Header="Lecteur"/>
            <TreeViewItem Header="Bibliotheque"/>                   
        </TreeView>
        <ListView Grid.Row="1">
            <ListView.Style>
                <Style TargetType="ListView">
                    <Setter Property="Visibility" Value="Visible"/>
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding ElementName=TrV,Path=SelectedItem.Header}">
                            <DataTrigger.Value>
                                <system:String>Lecteur</system:String>
                            </DataTrigger.Value>
                            <Setter Property="Visibility" Value="Hidden"/>
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </ListView.Style>
            <ListViewItem Content="Lv_One"/>
            <ListViewItem Content="Lv_Two"/>
            <ListViewItem Content="Lv_Three"/>
        </ListView>
        <MediaElement Grid.Row="2" >
            <MediaElement.Style>
                <Style TargetType="MediaElement">
                    <Setter Property="Visibility" Value="Visible"/>
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding ElementName=TrV,Path=SelectedItem.Header}">
                            <DataTrigger.Value>
                                <system:String>Bibliotheque</system:String>
                            </DataTrigger.Value>
                            <Setter Property="Visibility" Value="Hidden"/>
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </MediaElement.Style>
        </MediaElement>       
    </Grid>
