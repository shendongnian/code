    public partial class App : Application
    {
        public App ()
        {
            var label = new Label {
                Text = "Test",
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                BackgroundColor = Color.Silver
            };
            var layout = new RelativeLayout ();
            layout.Children.Add (label,
                Constraint.Constant (50),
                Constraint.Constant (100),
                Constraint.Constant (260),
                Constraint.Constant (30));
            MainPage = new ContentPage {
                Content = layout
            };
    
            var fwd = true;
            layout.Animate ("bounce",
                (delta) => {
                    var d = fwd ? delta : 1.0 - delta;
                    var y = 100.0 + (50.0 * d);
                    var c = BoundsConstraint.FromExpression ((Expression<Func<Rectangle>>)(() => new Rectangle (50, y, 260, 30)), new View [0]);
                    RelativeLayout.SetBoundsConstraint(label, c);
                    layout.ForceLayout ();
                }, 16, 800, Easing.SinInOut, (f, b) => {
                    // reset direction
                    fwd = !fwd;
                }, () => {
                    // keep bouncing
                    return true;
                });
        }
    }
