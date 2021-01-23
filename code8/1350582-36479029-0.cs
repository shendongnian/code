    <UserControl.Resources>
                   <Storyboard x:Key="Storyboard1">
                            <DoubleAnimation Storyboard.TargetName="Studio" Storyboard.TargetProperty="Opacity" From="0" To="{Binding StudioOpacityValue}" Duration="0:0:2"/>
                            <DoubleAnimation Storyboard.TargetName="Studio" Storyboard.TargetProperty="RenderTransform.(TranslateTransform.X)" From="0" To="500"  Duration="0:0:2">
                                <DoubleAnimation.EasingFunction>
                                    <CubicEase EasingMode="EaseInOut"/>
                                </DoubleAnimation.EasingFunction>
                            </DoubleAnimation>      
                        </Storyboard>
                </UserControl.Resources>
    
             <Grid Name="mainGrid" >
    
            <Button x:Name ="Studio" Grid.Row="33" Grid.Column="57" Grid.ColumnSpan="36" Grid.RowSpan="36"  IsEnabled="{Binding IsStudioEnabled}" Opacity="{Binding StudioOpacityValue}" >
    			<i:Interaction.Triggers>
                        <i:EventTrigger EventName="FadeInMainButtonsAfterImport" SourceObject="{Binding Mode=OneWay}">
                            <ei:ControlStoryboardAction Storyboard="{StaticResource Storyboard1}"/>
                        </i:EventTrigger>
              <Button.RenderTransform>
                            <TranslateTransform/>
                        </Button.RenderTransform>
    
              </Button>
    
        <Grid>
