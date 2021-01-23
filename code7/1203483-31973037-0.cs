        <DataGrid HorizontalAlignment="Stretch" VerticalAlignment="Stretch" HeadersVisibility="Column"
		  AlternatingRowBackground="AntiqueWhite" AlternationCount="2"
		  ItemsSource="{Binding EquipLocations, UpdateSourceTrigger=PropertyChanged}"
		  SelectedItem="{Binding SelectedItem}"
		  CanUserAddRows="True" CanUserDeleteRows="True"
		  AutoGenerateColumns="False">
            <DataGrid.Columns>
                <DataGridTextColumn Binding="{Binding Name, Mode=TwoWay}" Header="Name"/>
                <DataGridTextColumn Binding="{Binding Abbr, Mode=TwoWay}" Header="Abbreviation"/>
                <DataGridComboBoxColumn Header="Uses Location" Width="120" 
		SelectedValueBinding="{Binding Path=ParentObjectId, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}"
		SelectedValuePath="Id"
		DisplayMemberPath="Abbr">
                    <DataGridComboBoxColumn.ElementStyle>
                        <Style TargetType="ComboBox">
                            <Setter Property="ItemsSource" Value="{Binding RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type UserControl}}, 
					Path=DataContext.AllPossibleObjects}"/>
                        </Style>
                    </DataGridComboBoxColumn.ElementStyle>
                    <DataGridComboBoxColumn.EditingElementStyle>
                        <Style TargetType="ComboBox">
                            <Setter Property="ItemsSource" Value="{Binding RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type UserControl}}, 
					Path=DataContext.PossibleParentObjects}"/>
                        </Style>
                    </DataGridComboBoxColumn.EditingElementStyle>
                    <i:Interaction.Triggers>
                        <i:EventTrigger EventName="SelectionChanged">
                            <i:InvokeCommandAction Command="{Binding DataGridChanged}"/>
                        </i:EventTrigger>
                    </i:Interaction.Triggers>
                </DataGridComboBoxColumn>
                <DataGridTextColumn Binding="{Binding Desc, Mode=TwoWay}" Header="Description"/>
            </DataGrid.Columns>
            <i:Interaction.Triggers>
                <i:EventTrigger EventName="CurrentCellChanged">
                    <i:InvokeCommandAction Command="{Binding DataGridChanged}"/>
                </i:EventTrigger>
            </i:Interaction.Triggers>
        </DataGrid>
