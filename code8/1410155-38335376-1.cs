    <Grid>
            <DataGrid ItemsSource="{Binding Students}" AutoGenerateColumns="False"  Margin="69,50,47,66">
                <DataGrid.Columns>
                    <DataGridTextColumn Binding="{Binding Name}" Header="Names"/>
                    <DataGridComboBoxColumn SelectedValueBinding="{Binding Grade}" Header="Grades" Width="80">
                        <DataGridComboBoxColumn.EditingElementStyle>
                            <Style TargetType="{x:Type ComboBox}">
                                <Setter Property="ItemsSource" Value="{Binding Grades, Mode=TwoWay , UpdateSourceTrigger=PropertyChanged}" />
                            </Style>
                        </DataGridComboBoxColumn.EditingElementStyle>
                    </DataGridComboBoxColumn>
                    <DataGridCheckBoxColumn Binding="{Binding GoodStudent , UpdateSourceTrigger=PropertyChanged, Mode=OneWay}" Header="IsGood" />
                </DataGrid.Columns>
            </DataGrid>
        </Grid>
