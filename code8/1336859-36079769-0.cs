	<Style TargetType="Button">
		<Setter Property="IsEnabled" Value="True" />
		<Style.Triggers>
			<MultiDataTrigger>
				<MultiDataTrigger.Conditions>
					<Condition Binding="{Binding ElementName=listBox1, Path=Items.Count}" Value="0" />
				</MultiDataTrigger.Conditions>
				<Setter Property="IsEnabled" Value="False" />
			</MultiDataTrigger>
		</Style.Triggers>
	</Style>
