        <Canvas x:Name="MyCanvas" Background="#00FFFFFF">
        <i:Interaction.Behaviors>
            <!--convert event to command mechanism-->
            <soSandBox:CanvasMouseEventObservingBehavior 
                OnMouseMoveAction="{Binding OnMouseMoveAction, UpdateSourceTrigger=PropertyChanged}"
                OnMouseRightButtonDownAction="{Binding OnMouseRightButtonDownAction, UpdateSourceTrigger=PropertyChanged}"
                OnMouseRightButtonUpAction="{Binding OnMouseRightButtonUpAction, UpdateSourceTrigger=PropertyChanged}"/>
        </i:Interaction.Behaviors>
        <Rectangle x:Name="_MyTestRect1" Fill="Tomato" Width="50" Height="50">
            <Rectangle.RenderTransform>
                <TransformGroup>
                    <TranslateTransform X="{Binding TranslateTransformX, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}" 
                                        Y="{Binding TranslateTransformY, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}"></TranslateTransform>
                </TransformGroup>
            </Rectangle.RenderTransform>
        </Rectangle></Canvas>
