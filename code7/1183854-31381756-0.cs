     <StackPanel>
        <Button Name="Button"/>
        <Rectangle>
            <Rectangle.Style>
                <Style TargetType="Rectangle">
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding ElementName=Button, Path=IsPressed}" Value="True">
                            <DataTrigger.EnterActions>
                                <BeginStoryboard>
                                    <Storyboard>
                                        
                                    </Storyboard>
                                </BeginStoryboard>
                            </DataTrigger.EnterActions>
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </Rectangle.Style>
        </Rectangle>
    </StackPanel> 
