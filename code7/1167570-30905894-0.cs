            var checkBox = FindViewById<CheckBox>(Resource.Id.CheckBox1);
            checkBox.CheckedChange += (sender, args) =>
            {
                if (!args.IsChecked)
                {
                    
                }
            };
            checkBox.Click += (sender, args) =>
            {
                if (!checkBox.Checked)
                {
                    
                }
                if (!((CheckBox)sender).Checked)
                {
                    
                }
            };
