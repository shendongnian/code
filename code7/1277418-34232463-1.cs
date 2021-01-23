        void AddRotationAnimation(Storyboard sbRotate, int charIndex)
        {
            DoubleAnimation anim = new DoubleAnimation(0, 360, new Duration(new TimeSpan(0, 0, 0, 3))); //0 to 360 over 3 seconds
            Storyboard.SetTargetName(anim, "txtABC"); 
            SetBeginTime(anim, charIndex);
            string path = string.Format("TextEffects[{0}].Transform.Children[1].Angle", charIndex);
            PropertyPath propPath = new PropertyPath(path);
            
            Storyboard.SetTargetProperty(anim, propPath);
            sbRotate.Children.Add(anim);
        }
