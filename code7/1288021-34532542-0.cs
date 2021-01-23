    <Grid>
        <Button Width="100" Height="50" VerticalAlignment="Top" x:Name="SomeButton"></Button>
        <TextBox Width="200" Height="200" Background="Red" Opacity="0" Text="Some TextBox">
            <TextBox.Style>
                <Style TargetType="{x:Type TextBox}">
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding ElementName=SomeButton, Path=IsMouseOver}" Value="True">
                            <DataTrigger.EnterActions>
                                <BeginStoryboard >
                                    <Storyboard TargetProperty="Opacity" Duration="00:00:01" AutoReverse="True">
                                        <DoubleAnimation From="0" To="1" Duration="00:00:01"/>
                                    </Storyboard>
                                </BeginStoryboard>
                            </DataTrigger.EnterActions>
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </TextBox.Style>
        </TextBox>
    </Grid>
