    <DataGridCheckBoxColumn Binding="{Binding IsOEM,UpdateSourceTrigger=PropertyChanged}" Header="OEM">
                        <i:Interaction.Triggers>
                            <i:EventTrigger EventName="Checked">
                                <i:InvokeCommandAction Command="{Binding CheckBoxChecked,Mode=TwoWay,RelativeSource={RelativeSource AncestorType=DataGrid}}" CommandParameter="{Binding ElementName=dg,Path=SelectedItem}" />
                            </i:EventTrigger>
                        </i:Interaction.Triggers>
                    </DataGridCheckBoxColumn>
