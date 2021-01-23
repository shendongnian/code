    <StackPanel>
        <StackPanel.Resources>
            <BooleanToVisibilityConverter x:Key="VisibilityConverter" />
        </StackPanel.Resources>
        <GroupBox>
            <GroupItem>
                <StackPanel>
                    <RadioButton Content="Food" x:Name="rdbFood" IsChecked="{Binding IsFoodProperty}" ></RadioButton>
                    <RadioButton Content="Drinks" x:Name="rdbDrinks" IsChecked="{Binding IsDrinkProperty}"></RadioButton>
                </StackPanel>
            </GroupItem>
        </GroupBox>
        <TextBox Text="{Binding TextBox1}" Visibility="{Binding ElementName=rdbFood, Path=IsChecked, Converter={StaticResource VisibilityConverter}}"></TextBox>
        <TextBox Text="{Binding TextBox2}" Visibility="{Binding ElementName=rdbFood, Path=IsChecked, Converter={StaticResource VisibilityConverter}}"></TextBox>
        <ComboBox SelectedItem="{Binding SelectedDrink}" Visibility="{Binding ElementName=rdbDrinks, Path=IsChecked, Converter={StaticResource VisibilityConverter}}"></ComboBox>
        <Button Content="Submit" Command="{Binding EnableProcessButton}"></Button>
    </StackPanel>
