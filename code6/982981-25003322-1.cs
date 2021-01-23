    <StackPanel DataContext="{StaticResource MainViewModel}">
        <TextBox Text="{Binding Quantity, UpdateSourceTrigger=PropertyChanged}" 
                 Margin="4" />
        <TextBox Text="{Binding Rate, UpdateSourceTrigger=PropertyChanged}"
                 Margin="4" />
        <TextBox Margin="4">
            <TextBox.Text>
                <MultiBinding Converter="{StaticResource AmountConverter}">
                    <Binding Path="Quantity" UpdateSourceTrigger="PropertyChanged" />
                    <Binding Path="Rate" UpdateSourceTrigger="PropertyChanged" />
                </MultiBinding>
            </TextBox.Text>
        </TextBox>
    </StackPanel>
