            var mouseEnters =
                Observable
                    .FromEventPattern(
                        h => button1.MouseEnter += h,
                        h => button1.MouseEnter -= h);
            var mouseLeaves =
                Observable
                    .FromEventPattern(
                        h => button1.MouseLeave += h,
                        h => button1.MouseLeave -= h);
            var mouseUps =
                Observable
                    .FromEventPattern<MouseEventHandler, MouseEventArgs>(
                        h => button1.MouseUp += h,
                        h => button1.MouseUp -= h);
