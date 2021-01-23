            for (var n = 0; n <= 9; n++)
            {
                var btn =
                    this
                        .Controls
                        .Find("btnNum" + n.ToString(), false)
                        .Cast<Button>()
                        .First();
                var digit = n;
                btn.Click += (s, e) =>
                {
                    txtOutput.Text = digit.ToString();
                };
            }
