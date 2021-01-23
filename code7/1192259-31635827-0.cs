        private static void SetButtonSize(Graphics gr, Button button) {
            VisualStyleElement ButtonElement = VisualStyleElement.Button.PushButton.Normal;
            var visualStyleRenderer = new VisualStyleRenderer(ButtonElement.ClassName, ButtonElement.Part, 0);
            var bounds = visualStyleRenderer.GetBackgroundContentRectangle(gr, button.Bounds);
            var margin =  button.Height - bounds.Height;
            var fmt = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak;
            var prop = new Size(bounds.Width, 0);
            var size = TextRenderer.MeasureText(button.Text, button.Font, prop, fmt);
            button.ClientSize = new Size(button.ClientSize.Width, size.Height - margin);
        }
        protected override void OnLoad(EventArgs e) {
            using (var gr = this.CreateGraphics()) {
                SetButtonSize(gr, this.button1);
            }
            base.OnLoad(e);
        }
