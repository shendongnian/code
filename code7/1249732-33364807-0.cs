    <ListBox Name="simpleListBox"
             ItemsSource="{Binding Cars}"
            SelectedItem="{Binding SelectedCar}">
        <ListBox.ItemContainerStyle>
            <Style TargetType="ListBoxItem">
                <Setter Property="ContextMenu">
                    <Setter.Value>
                        <ContextMenu>
                            ...
                        </ContextMenu>
                    </Setter.Value>
                </Setter>
            </Style>
        </ListBox.ItemContainerStyle>
    </ListBox>
