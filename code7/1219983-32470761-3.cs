    <Page.Resources>
        <vm:ProductViewModel x:Key="product"/>
        <vm:SupplierViewModel x:Key="supplier"/>
        <DataTemplate x:Key="SupplierDataTemplate">
            <TextBlock Text="{Binding supplier}"/>
        </DataTemplate>
    </Page.Resources>
    <Grid>
        <StackPanel>
            <Grid DataContext="{Binding Source={StaticResource product}}" x:Name="ProductGrid">
                <StackPanel Grid.ColumnSpan="2" Margin="0,0,58,0">
                    <Button  x:Name="BtnDelete"
                Content="Delete" 
                Command="{Binding DeleteCommand}"/>
                    <Button  x:Name="BtnAdd" 
                Content="Save" 
                Command="{Binding SaveCommand}"/>
                    <DataGrid x:Name="dataGrid" Margin="5"  ItemsSource="{Binding Collection}" AutoGenerateColumns="False">
                        <DataGrid.Columns>
                            <DataGridTextColumn Header="id" Binding="{Binding idproduct, UpdateSourceTrigger=PropertyChanged}" Visibility="Hidden"/>
                            <DataGridTextColumn Header="Ref FTHK" Binding="{Binding ref, UpdateSourceTrigger=PropertyChanged}" />
                            <DataGridComboBoxColumn Header="Supplier" ItemsSource="{Binding Collection, Source={StaticResource supplier}}"
                                                    DisplayMemberPath="supplier" 
                                                    SelectedValueBinding="{Binding Path=DataContext.foodSupplier.idfoodSupplier, 
                                                        ElementName=ProductGrid}" 
                                                    SelectedValuePath="idSupplier"/>
                            <DataGridTextColumn Header="Ref Supplier" Binding="{Binding refsup, UpdateSourceTrigger=PropertyChanged}"/>
                            <DataGridTextColumn Header="Description" Binding="{Binding description, UpdateSourceTrigger=PropertyChanged}"/>
                            <DataGridTextColumn Header="MOQ" Binding="{Binding MOQ, UpdateSourceTrigger=PropertyChanged}"/>
                            <DataGridTextColumn Header="Unit" Binding="{Binding unit, UpdateSourceTrigger=PropertyChanged}"/>
                            <DataGridTextColumn Header="Prix/MOQ" Binding="{Binding priceMOQ, UpdateSourceTrigger=PropertyChanged}"/>
                        </DataGrid.Columns>
                        <!--<i:Interaction.Triggers>
                            <i:EventTrigger EventName="Loaded">
                                <i:InvokeCommandAction Command="{Binding GetCommand}" />
                            </i:EventTrigger>
                        </i:Interaction.Triggers>-->
                    </DataGrid>
                </StackPanel>
            </Grid>
        </StackPanel>
    </Grid>
