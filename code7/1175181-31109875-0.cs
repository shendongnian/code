    void Main()
    {
        Form frm = new Form();
        var btn = new Button { Text = "Start" };
        btn.Click += (_, __) =>
            {
                var clicks = new List<Point>();
                
                MouseEventHandler mouseUp = (s, e) =>
                    {
                        clicks.Add(e.Location);
                    };
                
                var eventHelper = new EventHelper { MouseUp = mouseUp };
                
                KeyEventHandler keyUp = (s, e) =>
                    {
                        if (e.KeyCode == Keys.Return)
                        {
                            frm.MouseUp -= eventHelper.MouseUp;
                            frm.KeyUp -= eventHelper.KeyUp;
                            btn.Enabled = true;
                        
                            // Finish
                            clicks.Dump();
                        }
                    };
                    
                eventHelper.KeyUp = keyUp;
                
                frm.MouseUp += mouseUp;
                frm.KeyUp += keyUp;
                btn.Enabled = false;
            };
            
        frm.Controls.Add(btn);
        
        Application.Run(frm);
    }
    
    class EventHelper
    {
        public MouseEventHandler MouseUp;
        public KeyEventHandler KeyUp;
    }
