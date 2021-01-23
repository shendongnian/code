    namespace MyOverrideConrols
    {
        public class MyProgressBar : ProgressBar
        {
            public MyProgressBar()
                : base()
            {
                this.NewDotSize = 20;
            }
            public MyProgressBar(int dot_size = 20)
                : base()
            {
                
                this.NewDotSize = (dot_size <= 0) ? 1 : dot_size;
            }
    
            public int NewDotSize{ get; set; }
    
            public override void OnApplyTemplate()
            {
                base.OnApplyTemplate();
                Rectangle slider_0 = (Rectangle)this.GetTemplateChild("Slider0"); ResizeRectangle(ref slider_0, NewDotSize);
                Rectangle slider_1 = (Rectangle)this.GetTemplateChild("Slider1"); ResizeRectangle(ref slider_1, NewDotSize);
                Rectangle slider_2 = (Rectangle)this.GetTemplateChild("Slider2"); ResizeRectangle(ref slider_2, NewDotSize);
                Rectangle slider_3 = (Rectangle)this.GetTemplateChild("Slider3"); ResizeRectangle(ref slider_3, NewDotSize);
                Rectangle slider_4 = (Rectangle)this.GetTemplateChild("Slider4"); ResizeRectangle(ref slider_4, NewDotSize);
                Rectangle slider_5 = (Rectangle)this.GetTemplateChild("Slider5"); ResizeRectangle(ref slider_5, NewDotSize);
    
            }
    
            private void ResizeRectangle(ref Rectangle rect, int new_size)
            {
                if (rect == null)
                    return;
                rect.Width = new_size;
                rect.Height = new_size;
            }
        }
    }
