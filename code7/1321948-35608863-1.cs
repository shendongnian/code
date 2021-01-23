                <telerik:GridViewDataColumn Header="Position">
                    <telerik:GridViewDataColumn.CellTemplate>
                        <DataTemplate>
                            <TextBlock>
                                <TextBlock.Text>
                                    <MultiBinding Converter="{StaticResource PositionConverter}">
                                        <Binding Path="EmployeeLevelID"/>
                                        <Binding RelativeSource="{RelativeSource Mode=FindAncestor, AncestorType=UserControl}" Path="DataContext.EmployeeLevels"/>
                                    </MultiBinding>
                                </TextBlock.Text>
                            </TextBlock>
                        </DataTemplate>
                    </telerik:GridViewDataColumn.CellTemplate>
                </telerik:GridViewDataColumn>
