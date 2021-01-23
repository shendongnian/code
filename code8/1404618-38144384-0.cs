    <Style x:Key="NewFrameStyle" TargetType="Frame">       
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="Frame">
                             <Grid Background="Gray">
                                 <SplitView>
                                     <SplitView.Pane>
                                      ...
                                     </SplitView.Pane>
                                     <SplitView.Content>
                                      ...
                                     </SplitView.Content>                                
                             </Grid>
                    </Setter.Value>
                 </Setter>
    </Style>
     protected override void OnLaunched(LaunchActivatedEventArgs e)
     {
          ...
          Frame rootFrame = Window.Current.Content as Frame;
          ...
          rootFrame.Style = this.Resources["NewFrameStyle"] as Style;
     }
