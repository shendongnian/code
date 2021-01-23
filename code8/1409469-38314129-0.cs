	<ComboBox Name="cb" SelectedValuePath="Content">
		<ComboBoxItem>A</ComboBoxItem>
		<ComboBoxItem>B</ComboBoxItem>
		<ComboBoxItem>Other</ComboBoxItem>
	</ComboBox>
	<TextBox>
		<TextBox.Style>
			<Style TargetType="TextBox">
				<Setter Property="Visibility" Value="Collapsed"/>
				<Style.Triggers>
					<DataTrigger Binding="{Binding SelectedValue, ElementName=cb}" Value="Other">
						<Setter Property="Visibility" Value="Visible"/>
					</DataTrigger>
				</Style.Triggers>
			</Style>
		</TextBox.Style>
	</TextBox>
