        <Style x:Key="ListViewItemStyle2" TargetType="{x:Type ListViewItem}">
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="{x:Type ListViewItem}">
                        <Border x:Name="ListBoxItemRoot" 
                                BorderBrush="{TemplateBinding BorderBrush}" 
                                BorderThickness="1,0" 
                                Background="{TemplateBinding Background}" 
                                CornerRadius="2" 
                                Uid="Border_57">
                            <GridViewRowPresenter Columns="{TemplateBinding GridView.ColumnCollection}" 
                                                  Content="{TemplateBinding Content}" 
                                                  HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" 
                                                  Margin="{TemplateBinding Padding}" 
                                                  Uid="GridViewRowPresenter_1" 
                                                  VerticalAlignment="{TemplateBinding VerticalContentAlignment}"/>
                            <VisualStateManager.VisualStateGroups>
                                <VisualStateGroup x:Name="CommonStates">
                                    <VisualState x:Name="Normal"></VisualState>
                                    <VisualState x:Name="Disabled"></VisualState>
                                    <VisualState x:Name="MouseOver"></VisualState>
                                </VisualStateGroup>
                                <VisualStateGroup x:Name="SelectionStates">
                                    <VisualState x:Name="Selected"></VisualState>
                                    <VisualState x:Name="Unselected"></VisualState>
                                </VisualStateGroup>
                            </VisualStateManager.VisualStateGroups>
                        </Border>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
            <Style.Triggers>
                <Trigger Property="IsMouseOver" Value="true">
                    <Setter Property="Background" Value="LightGreen" />
                    <Setter Property="Foreground" Value="Orange" />
                </Trigger>
                <Trigger Property="IsSelected" Value="true">
                    <Setter Property="Background" Value="LightCoral" />
                    <Setter Property="Foreground" Value="White" />
                </Trigger>
            </Style.Triggers>
        </Style>
