            var downs =
                Observable
                    .FromEventPattern<MouseEventHandler, MouseEventArgs>(
                        h => pbMove.MouseDown += h, h => pbMove.MouseDown -= h)
                    .Select(x => x.EventArgs);
            var moves =
                Observable
                    .FromEventPattern<MouseEventHandler, MouseEventArgs>(
                        h => pbMove.MouseMove += h, h => pbMove.MouseMove -= h)
                    .Select(x => x.EventArgs);
            var ups =
                Observable
                    .FromEventPattern<MouseEventHandler, MouseEventArgs>(
                        h => pbMove.MouseUp += h, h => pbMove.MouseUp -= h)
                    .Select(x => x.EventArgs);
