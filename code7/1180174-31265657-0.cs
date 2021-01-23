                <DataGridTemplateColumn Header="Bucht">
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <ComboBox ItemsSource="{Binding DataContext.Pens, RelativeSource={RelativeSource AncestorType={x:Type view:AdministrationView}}}" DisplayMemberPath="Name" SelectedItem="{Binding Pen, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" SelectedValue="{Binding Pen.PenId}" SelectedValuePath="PenId">
                                <i:Interaction.Triggers>
                                    <i:EventTrigger EventName="SelectionChanged">
                                        <i:InvokeCommandAction Command="{Binding DataContext.SaveCommand, RelativeSource={RelativeSource AncestorType={x:Type view:AdministrationView}}}" />
                                    </i:EventTrigger>
                                </i:Interaction.Triggers>
                            </ComboBox>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
