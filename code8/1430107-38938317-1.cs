	<Style TargetType="{x:Type ListBoxItem}">
		<Setter Property="Template">
			<Setter.Value>
				<ControlTemplate TargetType="ListBoxItem">
					<Border Name="BorderWrap">
						<ContentPresenter />
					</Border>
					<ControlTemplate.Triggers>
						<MultiDataTrigger>
                            <MultiDataTrigger.Conditions>
							    <Condition Binding="{Binding RelativeSource={RelativeSource Self},Path=IsSelected}" Value="True" />
							    <Condition Binding="{Binding Data.IsValid}" Value="True" />
                            </MultiDataTrigger.Conditions>
                            <MultiDataTrigger.Setters>
							    <Setter TargetName="BorderWrap" Property="Background" Value="{StaticResource StatusValid}"/>
                            </MultiDataTrigger.Setters>
						</MultiDataTrigger>
						<MultiDataTrigger>
                            <MultiDataTrigger.Conditions>
							    <Condition Binding="{Binding RelativeSource={RelativeSource Self},Path=IsSelected}" Value="True" />
							    <Condition Binding="{Binding Data.IsValid}" Value="False" />
                            </MultiDataTrigger.Conditions>
                            <MultiDataTrigger.Setters>
							    <Setter TargetName="BorderWrap" Property="Background" Value="{StaticResource StatusInvalid}"/>
                            <MultiDataTrigger.Setters>
						</MultiDataTrigger>
					</ControlTemplate.Triggers>
				</ControlTemplate>
			</Setter.Value>
		</Setter>
	</Style>
