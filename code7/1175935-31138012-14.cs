    <Grid>
         <DataGrid x:Name=x:Name="myDataGrid">
        ....
         
                            <MultiBinding Converter="{StaticResource multiConv}">
                                <Binding Path="(Validation.Errors)[0].ErrorContent" RelativeSource="{RelativeSource Mode=FindAncestor,
                                                    AncestorType=DataGridRow}"/>
                                <Binding Path="DataContext.Error" RelativeSource="{RelativeSource Mode=FindAncestor,
                                                    AncestorType=Window}"/>
                            </MultiBinding>
                        </Grid.ToolTip>
                    </Grid>
                </ControlTemplate>
            </DataGrid.RowValidationErrorTemplate>
        </DataGrid>
        <TextBox Grid.Row="1" Text="{Binding Error.Message}"/>
    </Grid>
