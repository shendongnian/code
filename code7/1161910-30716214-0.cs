    <Trigger.EnterActions>
                <BeginStoryboard>
                  <Storyboard>
                    <DoubleAnimation Storyboard.TargetProperty="Opacity"
                      To="1" Duration="0:0:1" />
                  </Storyboard>
                </BeginStoryboard>
              </Trigger.EnterActions>
              <Trigger.ExitActions>
                <BeginStoryboard>
                  <Storyboard>
                    <DoubleAnimation Storyboard.TargetProperty="Opacity"
                      To="0.25" Duration="0:0:1" />
                  </Storyboard>
                </BeginStoryboard>
              </Trigger.ExitActions>          
            </Trigger>    
