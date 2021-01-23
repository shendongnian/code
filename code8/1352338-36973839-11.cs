    <StackPanel>
        <Label Content="Log On"></Label>
        <TextBox Text="{Binding Path=CurrentUser.UserName, Mode=TwoWay}"></TextBox>
        <TextBox Text="{Binding Path=CurrentUser.Password, Mode=TwoWay}"></TextBox>
        <Button Content="Log In" Command="{Binding DataContext.SelectViewCommand, ElementName=Base_V}" CommandParameter="{Binding LogOnCommandParameter}" ></Button>
        <Button Content="Recovery" Command="{Binding DataContext.SelectViewCommand, ElementName=Base_V}" CommandParameter="{Binding RecoveryCommandParameter}" ></Button>
        <Button Content="Regester" Command="{Binding DataContext.SelectViewCommand, ElementName=Base_V}" CommandParameter="{Binding RegesterCommandParameter}" ></Button>
    </StackPanel>
