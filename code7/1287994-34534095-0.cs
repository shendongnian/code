      <Grid 
            Background="Black"
            mousebehav:MouseBehaviour.MouseLeftButtonUpCommand="{Binding MLBUCommand}">
            <Canvas >
                <Image RenderTransformOrigin="0.5,0.5"                        
                       Source="{Binding ImageSource}"
                       Stretch="None"  SnapsToDevicePixels="False"
                       mousebehav:MouseBehaviour.MouseLeftButtonDownCommand="{Binding MDCommand}"
                       mousebehav:MouseBehaviour.MouseMoveCommand="{Binding MMCommand}">
                    <Image.RenderTransform>
                        <TranslateTransform  
                            X="{Binding MouseX}" 
                            Y="{Binding MouseY}" />   
                    </Image.RenderTransform>
                    <Image.LayoutTransform>
                        <TransformGroup>
                            <ScaleTransform 
                                ScaleX="{Binding ScaleX}" 
                                ScaleY="{Binding ScaleY}"/>
                            <RotateTransform 
                                Angle="{Binding RotateAngle}"/>
                        </TransformGroup>
                    </Image.LayoutTransform>
                </Image>
            </Canvas>
        </Grid>      
