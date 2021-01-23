        private RelayCommand<BitmapModel> _changeTileCommand;
            public RelayCommand<BitmapModel> ChangeTilesCommand {
                get { return _changeTileCommand ?? (_changeTileCommand = new RelayCommand<BitmapModel>(UpdateTile, CanDraw)); }
            }
    
    private RelayCommand<MouseEventArgs> _drawingCommand;
    public RelayCommand<MouseEventArgs> DrawingCommand {
                get { return _drawingCommand ?? (_drawingCommand = new RelayCommand<MouseEventArgs>(MouseDown)); }
    }
    
    
    void MouseDown(MouseEventArgs mouse) {
                if (mouse.LeftButton == MouseButtonState.Pressed) _mouseDown = true;
                else if (mouse.LeftButton == MouseButtonState.Released) _mouseDown = false;
    }
    
    bool CanDraw(BitmapModel tile) {
                return _mouseDown;
    }
