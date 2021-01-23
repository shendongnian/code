    <Grid>
        <Grid.Resources>
            <ControlTemplate x:Key="buttonTemplate" TargetType="{x:Type Button}">
                <Grid>
                    <Rectangle x:Name="Rect" Width="100" Height="100" Fill="Aqua"/>
                    
                    <Viewbox>
                        <ContentControl Margin="20" Content="{TemplateBinding Content}"/>
                    </Viewbox>
                </Grid>
                <ControlTemplate.Triggers>
                    <Trigger Property="IsMouseOver" Value="True">
                        <Setter TargetName="Rect" Property="Fill" Value="Orange"/>
                    </Trigger>
                  
                </ControlTemplate.Triggers>
            </ControlTemplate>
        </Grid.Resources>
        <Button Template="{StaticResource buttonTemplate}">OK</Button>
    </Grid>
