           public  void Move(object sender, KeyEventArgs e)
        {
            if(e.IsDown && !isPressed)
            {
                isPressed = true;
                if (e.Key == Key.D)
                {
                    hareket(true);
                }
                if (e.Key == Key.A)
                {
                    hareket(false);
                }
            }
            else
            {
                isPressed = false;
            }
        }
        private void hareket(bool IncreaseOrDecrease)
        {
            myStoryboard.Children.Remove(myDoubleAnimation);
            if ((IncreaseOrDecrease)&&(myDoubleAnimation.To < 90 ))
            {
                myDoubleAnimation.To++;
            }
            else if ((!IncreaseOrDecrease) && (myDoubleAnimation.To > -90))
            {
                myDoubleAnimation.To--;
            }
            myStoryboard.Children.Add(myDoubleAnimation);
                myStoryboard.Begin();
                Degree.Content = myDoubleAnimation.To;
        }
