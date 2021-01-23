    <ScrollViewer x:Name="vbxImageViewBox" 
                  CanContentScroll="False" 
                  HorizontalScrollBarVisibility="Auto"
                  VerticalScrollBarVisibility="Auto">
        <Grid x:Name="grdItcMain" Margin="5">
             <Grid.LayoutTransform>
                <TransformGroup>
                    <ScaleTransform 
                        ScaleX="{Binding Path=ScaleFactor, 
                                 ElementName=this, 
                                 Mode=OneWay}" 
                        ScaleY="{Binding Path=ScaleFactor, 
                                 ElementName=this, 
                                 Mode=OneWay}" />
                </TransformGroup>
            </Grid.LayoutTransform>
            <Rectangle Fill="DeepSkyBlue" Stretch="Fill" />
            <Image MouseWheel="Image_MouseWheel"
                Source="{Binding PreviewSource,
                         ElementName=this,
                         Mode=OneWay}"
                Stretch="Fill" />
        </Grid>
    </ScrollViewer>
    private const double _smallChange = 0.1;
    private double _scaleFactor;
    public double ScaleFactor 
    { 
        get 
        { 
            return _scaleFactor; 
        } 
        set 
        { 
            _scaleFactor = value; 
            OnPropertyChanged("ScaleFactor"); 
        } 
    }
    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
         double scaleX = (grdItcMain.ActualWidth - 20) / 1920;
         double scaleY = (grdItcMain.ActualHeight - 20) / 1080;
         double dScale = Math.Min(scaleX, scaleY);
         ScaleFactor = dScale; //size to fit initially
    }
    private void Image_MouseWheel(object sender, MouseWheelEventArgs e)
    {
        if (e.Delta > 0)
        {
            if ((ScaleFactor + _smallChange) > 25.0)
            {
                return;
            }
            ScaleFactor += _smallChange;
            vbxImageViewBox.LineRight();
            vbxImageViewBox.LineRight();
            vbxImageViewBox.LineRight();
            vbxImageViewBox.LineRight();
            vbxImageViewBox.LineRight();
            vbxImageViewBox.LineDown();
            vbxImageViewBox.LineDown();
            vbxImageViewBox.LineDown();
            vbxImageViewBox.LineDown();
            vbxImageViewBox.LineDown();
            vbxImageViewBox.LineDown();
        }
        else
        {
            if ((ScaleFactor - _smallChange) < 0.001)
            {
                return;
            }
            ScaleFactor -= _smallChange;
            vbxImageViewBox.LineLeft();
            vbxImageViewBox.LineLeft();
            vbxImageViewBox.LineLeft();
            vbxImageViewBox.LineLeft();
            vbxImageViewBox.LineLeft();
            vbxImageViewBox.LineUp();
            vbxImageViewBox.LineUp();
            vbxImageViewBox.LineUp();
            vbxImageViewBox.LineUp();
            vbxImageViewBox.LineUp();
            vbxImageViewBox.LineUp();
            }
        }
