     <DataGridComboBoxColumn Header="ActivityStatus" SelectedItemBinding="{Binding IsActive, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}">
                <DataGridComboBoxColumn.ItemsSource>
                    <x:Array Type="system:Boolean">
                        <system:Boolean>True</system:Boolean>
                        <system:Boolean>False</system:Boolean>
                    </x:Array>
                </DataGridComboBoxColumn.ItemsSource>
            </DataGridComboBoxColumn>
