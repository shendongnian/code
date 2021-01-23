    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition />
            <ColumnDefinition />
            <ColumnDefinition />
            <ColumnDefinition />
            <ColumnDefinition />
        </Grid.ColumnDefinitions>
        <Button x:Uid="Button1" Grid.Column="0" Content="Button1" Click="{x:Bind ViewModel.DoButton1}" />
        <Button x:Uid="Button2" Grid.Column="1" Content="Button2" Click="{x:Bind ViewModel.DoButton2}" />
        <Button x:Uid="Button3" Grid.Column="2" Content="Button3" Click="{x:Bind ViewModel.DoButton3}" />
        <Button x:Uid="Button4" Grid.Column="3" Content="Button4" Click="{x:Bind ViewModel.DoButton4}" />
        <Button x:Uid="Button5" Grid.Column="4" Content="Button5" Click="{x:Bind ViewModel.DoButton5}" />
    </Grid>
