    <ContentControl>
      <ContentControl.InputBindings>
          <MouseBinding Gesture="LeftDoubleClick"
                        Command="{Binding RelativeSource={RelativeSource AncestorType=ItemsControl},Path=DataContext.ClientDoubleClickCommand}" 
                        CommandParameter="{Binding ClientId}"/>
          .
          .
          . [OTHER CODES HERE]
          .
          .
                               
      </ContentControl.InputBindings>
    </ContentControl>
