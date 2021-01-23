    private int _scollMoverIdx = 0;
        private TabControl _container;
    
        private void ScrollViewer_OnLoaded(object sender, RoutedEventArgs e) {
          this._container = (sender as ScrollViewer).TemplatedParent as TabControl;
        }
    
        public ICommand MoveLeftCommand => new RelayCommand(x => {
          if (this._scollMoverIdx == 0) {
            this._scollMoverIdx = this.someobslist.Count - 1;
            this._container.ScrollToCenterOfView(this.someobslist[_scollMoverIdx]);
          } else {
            _scollMoverIdx--;
            this._container.ScrollToCenterOfView(this.someobslist[_scollMoverIdx]);
          }
    
        });
    
        public ICommand MoveRightCommand => new RelayCommand(x => {
          if (this._scollMoverIdx == this.someobslist.Count - 1) {
            this._scollMoverIdx = 0;
            this._container.ScrollToCenterOfView(this.someobslist[_scollMoverIdx]);
          } else {
            _scollMoverIdx++;
            this._container.ScrollToCenterOfView(this.someobslist[_scollMoverIdx]);
          }
        });
