            var chekBox = (sender as CheckBox).IsChecked;
            if (chekBox==true)
            {
                count = count + 1;
            }
            if (count > 1)
            {
                (sender as CheckBox).IsChecked = false;
                count = 0;
            }
        }
