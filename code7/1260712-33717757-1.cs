                    <DataGridComboBoxColumn Header="Scores" 
                                        SelectedValueBinding="{Binding ScoreData, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}">
                    <DataGridComboBoxColumn.ElementStyle>
                        <Style TargetType="ComboBox">
                            <Setter Property="ItemsSource" Value="{StaticResource ScoresAndDescription}"/>
                            <Setter Property="DisplayMemberPath" Value="Score"></Setter>
                            <Setter Property="IsReadOnly" Value="True"/>
                        </Style>
                    </DataGridComboBoxColumn.ElementStyle>
                    <DataGridComboBoxColumn.EditingElementStyle>
                        <Style TargetType="ComboBox">
                            <Setter Property="ItemsSource" Value="{StaticResource ScoresAndDescription}"/>
                            <Setter Property="DisplayMemberPath" Value="ScoreVerbal"></Setter>
                            <Setter Property="IsReadOnly" Value="True"/>
                        </Style>
                    </DataGridComboBoxColumn.EditingElementStyle></DataGridComboBoxColumn>
