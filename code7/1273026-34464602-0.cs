        private void BTN_Close_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.FadeOut();
        }
        async private void FadeOut()
        {
            var anim = new DoubleAnimation(0, (Duration)TimeSpan.FromSeconds(0.2));
            this.BeginAnimation(UIElement.OpacityProperty, anim);
            await Task.Delay(200);
            this.Close(); 
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
