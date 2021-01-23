    <ItemsControl ItemsSource="{Binding Items}" Grid.Column="1" Name="Lst">
        <ItemsControl.Resources>
            <DataTemplate x:Key="CheckItem">
                <CheckBox Content="{Binding ObjectData}" 
                        IsChecked="{Binding IsSelected}" 
                        Margin="0,6,8,0"/>
            </DataTemplate>
            <DataTemplate x:Key="OthersItem">
                <StackPanel Orientation="Horizontal">
                    <CheckBox IsChecked="{Binding IsSelected}" 
                                Content="{Binding ObjectData}"
                                Margin="0,6,8,0"/>
                    <TextBox Margin="5,0" VerticalAlignment="Center"
                            MinWidth="50"
                            IsEnabled="{Binding IsSelected}"
                            IsHitTestVisible="True"
                            Text="{Binding Path=DataContext.Others, ElementName=Lst}"/>
                </StackPanel>
            </DataTemplate>
        </ItemsControl.Resources>
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <WrapPanel Orientation="Horizontal"/>
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <ContentPresenter Content="{Binding}">
                    <ContentPresenter.Style>
                        <Style TargetType="ContentPresenter">
                            <Setter Property="ContentTemplate" Value="{StaticResource CheckItem}"/>
                            <Style.Triggers>
                                <DataTrigger Binding="{Binding Path=ObjectData}" Value="Others">
                                    <Setter Property="ContentTemplate" Value="{StaticResource OthersItem}"/>
                                </DataTrigger>
                            </Style.Triggers>
                        </Style>
                    </ContentPresenter.Style>
                </ContentPresenter>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
