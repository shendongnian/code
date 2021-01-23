	<ListView 
		Margin="0,199,0,0"  
		VerticalAlignment="Stretch" 
		HorizontalAlignment="Stretch" 
		HorizontalContentAlignment="Stretch">
		<ListView.Style>
			<Style TargetType="ListView">
				<Setter Property="ItemsSource" Value="{Binding Source1}"/>
				<Setter Property="View">
					<Setter.Value>
						<GridView AllowsColumnReorder="True" ColumnHeaderToolTip="mammals">
							<GridViewColumn Header="AnimalReport1Header" Width="120" DisplayMemberBinding="{Binding type1name}"/>
						</GridView>
					</Setter.Value>
				</Setter>
				<Style.Triggers>
					<DataTrigger Binding="{Binding IsSource2}" Value="True">
						<Setter Property="ItemsSource" Value="{Binding Source2}"/>
						<Setter Property="View">
							<Setter.Value>
								<GridView AllowsColumnReorder="True" ColumnHeaderToolTip="mammals">
									<GridViewColumn Header="AnimalReport2Header" Width="120" DisplayMemberBinding="{Binding type2name}"/>
								</GridView>
							</Setter.Value>
						</Setter>
					</DataTrigger>
				</Style.Triggers>
			</Style>
		</ListView.Style>
	</ListView>
