        <Style TargetType="{x:Type ListView}">
            <Setter Property="Background" Value="Green"/>
            <Setter Property="Template">
				<Setter.Value>
					<ControlTemplate TargetType="{x:Type ListView}">
						<Microsoft_Windows_Themes:ListBoxChrome x:Name="Bd" BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" Background="{TemplateBinding Background}" RenderMouseOver="{TemplateBinding IsMouseOver}" RenderFocused="{TemplateBinding IsKeyboardFocusWithin}" SnapsToDevicePixels="true">
							<ScrollViewer Padding="{TemplateBinding Padding}" Style="{DynamicResource {x:Static GridView.GridViewScrollViewerStyleKey}}">
								<ItemsPresenter SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}"/>
							</ScrollViewer>
						</Microsoft_Windows_Themes:ListBoxChrome>
						<ControlTemplate.Triggers>
							<Trigger Property="IsGrouping" Value="true">
								<Setter Property="ScrollViewer.CanContentScroll" Value="false"/>
							</Trigger>
							<Trigger Property="IsEnabled" Value="false">
                                <!-- Here comes your custom disabled background color -->
								<Setter Property="Background" TargetName="Bd"
                                        Value="Red"/>
                                <!-- Here comes your custom disabled background color -->
							</Trigger>
						</ControlTemplate.Triggers>
					</ControlTemplate>
				</Setter.Value>
			</Setter>
        </Style>
