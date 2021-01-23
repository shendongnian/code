           foreach (UIElement ball in playArea.Children)
           {
               if(ball is ContentControl)
                    ball.Tapped += ball_Tapped;    
           }
        }
        void ball_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ContentControl ball = sender as ContentControl;
            double top = Canvas.GetTop(ball);
            animateBall(ball, top, playArea.ActualHeight, "(Canvas.Top)");
        }
