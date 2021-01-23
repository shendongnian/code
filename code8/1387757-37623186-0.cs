     <ComboBox ItemsSource="{Binding Items}">
            <ComboBox.ItemContainerStyle>
                <Style TargetType="ComboBoxItem">
                    <Setter Property="IsSelected" Value="{Binding SelectedA, Mode=OneWayToSource}"></Setter>
                    <Setter Property="IsEnabled" Value="{Binding SelectedB}"></Setter>
                </Style>
            </ComboBox.ItemContainerStyle>
        </ComboBox>
        <ComboBox ItemsSource="{Binding Items}">
            <ComboBox.ItemContainerStyle>
                <Style TargetType="ComboBoxItem">
                    <Setter Property="IsSelected" Value="{Binding SelectedB, Mode=OneWayToSource}"></Setter>
                    <Setter Property="IsEnabled" Value="{Binding SelectedA}"></Setter>
                </Style>
            </ComboBox.ItemContainerStyle>
        </ComboBox>
