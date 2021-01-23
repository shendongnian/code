        private void holdEvent(object sender, System.Windows.Input.GestureEventArgs e)
        {
            // Change the background of the exercise label
            Grid grid = (Grid)sender;
            grid.setBackground(Colors.Gray);         
            // Apply manipulation events
            grid.ManipulationDelta += new EventHandler<System.Windows.Input.ManipulationDeltaEventArgs>(GridMoving);
            grid.ManipulationCompleted += new EventHandler<ManipulationCompletedEventArgs>(GridMoved);
            
        }
        private void GridMoving(object sender, ManipulationDeltaEventArgs e)
        {
           // Manipulate the position of the grid here
        }
        private void ExerciseMoved(object sender, ManipulationCompletedEventArgs e)
        {
            //Change background colour back
            Grid grid = (Grid)sender;
            grid.setBackground(Colors.White); // Use the original colour here   
            
            // Remove the manipulation events from that specified grid, so it wont move,
            // when the user trys to move a different grid.
            grid.ManipulationDelta -= ExerciseMoving;
            grid.ManipulationCompleted -= ExerciseMoved;
        }
