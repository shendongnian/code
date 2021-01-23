            var hovers =
                Observable
                    .FromEventPattern(h => label1.MouseEnter += h, h => label1.MouseEnter -= h)
                    .Select(x => Observable.Timer(TimeSpan.FromSeconds(3.0)))
                    .Switch()
                    .Select(x => System.Drawing.Color.Red);
            var leaves =
                Observable
                    .FromEventPattern(h => label1.MouseLeave += h, h => label1.MouseLeave -= h)
                    .Select(x => System.Drawing.Color.White);
            var query = hovers.Merge(leaves);
            var subscription = query.ObserveOn(this).Subscribe(c => this.BackColor = c);
