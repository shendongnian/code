    <Page.Resources>
      <PointCollection x:Key="points">
         <Point>0,30</Point>
         <Point>20,50</Point>
         <Point>40,10</Point>
      </PointCollection>
    </Page.Resources>
    <Grid>  
      <Grid.Background>
       <DrawingBrush>
          <DrawingBrush.Drawing>
              <GeometryDrawing>
                 <GeometryDrawing.Pen>
                    <Pen Brush="Red" Thickness="1"></Pen>
                 </GeometryDrawing.Pen>
                 <GeometryDrawing.Geometry>
                    <PathGeometry>
                       <PathFigure>
                           <PolyLineSegment Points="{StaticResource points}"></PolyLineSegment>
                       </PathFigure>
                    </PathGeometry>
                 </GeometryDrawing.Geometry>
              </GeometryDrawing>
          </DrawingBrush.Drawing>
        </DrawingBrush>
      </Grid.Background>
    </Grid>
