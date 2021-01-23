    <TreeView>
      <TreeView.Resources>
         <DiscreteObjectKeyFrame x:Key="proxy" Value="{Binding}"/> 
      </TreeView.Resources>
      <TreeView.ItemContainerStyle>
          <Style TargetType="TreeViewItem">
             <Setter Property="local:InteractionX.Triggers">
                    <Setter.Value>            
                        <x:Array Type="{x:Type i:TriggerBase}">
                            <i:EventTrigger EventName="RequestBringIntoView">
                                <ei:CallMethodAction MethodName="bringIntoViewHandler" 
                                 TargetObject="{Binding Value, Source={StaticResource proxy}}"/>
                            </i:EventTrigger>
                        </x:Array>
                    </Setter.Value>
                </Setter>   
          </Style>
      </TreeView.ItemContainerStyle>
    </TreeView>
