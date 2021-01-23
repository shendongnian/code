    <StackPanel DataContext="{StaticResource MainViewModel}">
        <TextBox Text="{Binding Quantity, UpdateSourceTrigger=PropertyChanged}" 
                 Margin="4" />
        <TextBox Text="{Binding Rate, UpdateSourceTrigger=PropertyChanged}"
                 Margin="4" />
        <TextBox Margin="4">
            <TextBox.Text>
                <MultiBinding Converter="{StaticResource AmountConverter}"
                              UpdateSourceTrigger="PropertyChanged">
                    <Binding Path="Quantity" />
                    <Binding Path="Rate" />
                </MultiBinding>
            </TextBox.Text>
        </TextBox>
    </StackPanel>
