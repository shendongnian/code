    <ControlTemplate x:Key="Button">
            <Grid x:Name="button">                
                <Rectangle x:Name="ButtonTheme" RadiusX="10" RadiusY="10" Stroke="Silver" StrokeThickness="3" Fill="{TemplateBinding Background}"></Rectangle>
                <Rectangle x:Name="HighLight" Opacity="1.0" Tag="1">
                    <Rectangle.Resources>
                       <DiscreteObjectKeyFrame x:Key="proxy" Value="{Binding ElementName=HighLight}"/>
                    </Rectangle.Resources>
                    <Rectangle.Fill>
                        <RadialGradientBrush Center="0.5,0.8">
                            <GradientStop x:Name="Flower" Color="#AAFFFFFF" 
                                          Offset="{Binding Value.Tag, Source={StaticResource proxy}}" />
                            <GradientStop Color="#00FFFFFF" Offset="0" />
                        </RadialGradientBrush>
                    </Rectangle.Fill>
                </Rectangle>
                <ContentControl HorizontalAlignment="Center"
                                VerticalAlignment="Center"
                                Content= "{TemplateBinding Property = ContentControl.Content}" />
                 </Grid>
            <ControlTemplate.Triggers>
                <Trigger Property="IsMouseOver" Value="True">
                    <Setter TargetName="HighLight" Property="Tag" Value="0" />
                </Trigger>
            </ControlTemplate.Triggers>
     </ControlTemplate>
