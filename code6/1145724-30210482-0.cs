    <ListView ... 
       ItemsSource="{Binding ListViewCollection}" 
       SelectedItem="{Binding SelectedItem}" 
       SelectionMode="Single">
       <ListView.View>
           <!-- removed -->
       </ListView.View>
       <ListView.ItemContainerStyle>
          <Style TargetType="{x:Type ListViewItem}">
             <Style.Triggers>
                <EventTrigger RoutedEvent="GotKeyboardFocus">
                   <BeginStoryboard>
                      <Storyboard>
                         <BooleanAnimationUsingKeyFrames BeginTime="0:0:0" Duration="0:0:0" Storyboard.TargetProperty="IsSelected">
                            <DiscreteBooleanKeyFrame Value="True" />
                         </BooleanAnimationUsingKeyFrames>
                      </Storyboard>
                   </BeginStoryboard>
                </EventTrigger>
             </Style.Triggers>
          </Style>
       </ListView.ItemContainerStyle>
    </ListView>
