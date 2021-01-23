    class XXX{
        double scale = 1;
        public void PreviewMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e){
            this.scale *= Math.Pow(2, e.Delta / 3.0 / System.Windows.Input.Mouse.MouseWheelDeltaForOneLine);
            if (this.scale > 5) this.scale = 5;
            else if (this.scale < 1) this.scale = 1;
            MyCanvas.Scale = this.scale;
        }
    }
