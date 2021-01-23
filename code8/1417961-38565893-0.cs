        GridLengthAnimation gridAnim = new GridLengthAnimation() {
                Name = "gridAnim",
                Target = this.MainGrid.ColumnDefinitions[1],
                Duration = new Duration(TimeSpan.FromMilliseconds(1000))
              };
        
              gridAnim.From = new GridLength(1, GridUnitType.Star);
              gridAnim.To = new GridLength(0, GridUnitType.Star);
    //Cleanup on Complete
              gridAnim.Completed += (sender, args) => {
                                                        var xx = sender as AnimationClock;
                                                        (xx.Timeline as GridLengthAnimation).Target = null;
              };
              gridAnim.BeginAnimation();
