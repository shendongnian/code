    <MultiTrigger>
			<MultiTrigger.Conditions>
				<Condition Property="Selector.IsSelected">
					<Condition.Value>
						<s:Boolean>True</s:Boolean>
					</Condition.Value>
				</Condition>
				<Condition Property="TabItem.TabStripPlacement" Value="{x:Static Dock.Left}"/>
			</MultiTrigger.Conditions>
			<Setter Property="Control.Padding">
				<Setter.Value>
					<Thickness>11,2,14,2</Thickness>
				</Setter.Value>
			</Setter>
			<Setter Property="FrameworkElement.Margin">
				<Setter.Value>
					<Thickness>-2,-2,-2,-2</Thickness>
				</Setter.Value>
			</Setter>
		</MultiTrigger>
