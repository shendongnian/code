    <ListBox Grid.Row="0" ItemsSource="{Binding ViewModel.MyList}" 
             SelectedItem="{Binding ViewModel.MyItem}" >
        <ListBox.ItemContainerStyle>
            <Style TargetType="ListBoxItem">
                <Style.Triggers>
                    <DataTrigger Binding="{Binding YourEnumProperty}" Value="{x:Static vm:CarColors.Red}">
                        <Setter Property="Background" Value="Red"></Setter>
                    </DataTrigger>
                    <DataTrigger Binding="{Binding YourEnumProperty}" Value="{x:Static vm:CarColors.Green}">
                        <Setter Property="Background" Value="Green"></Setter>
                    </DataTrigger>
                    <DataTrigger Binding="{Binding YourEnumProperty}" Value="{x:Static vm:CarColors.Blue}">
                        <Setter Property="Background" Value="Blue"></Setter>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </ListBox.ItemContainerStyle>
    </ListBox>
