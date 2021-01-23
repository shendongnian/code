        <UserControl.Resources>
            <Style TargetType="ListBoxItem">
                <Style.Triggers>
                    <Trigger Property="IsFocused" Value="True">
                        <Setter Property="Selector.IsSelected" Value="True"></Setter>
                    </Trigger>
                </Style.Triggers>
            </Style>
        </UserControl.Resources>
        <ListBox>
            <ListBoxItem>
                Blah
            </ListBoxItem>
        </ListBox>
