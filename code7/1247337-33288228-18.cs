    static class DnDCtl
    {
        static List<Control> Targets = new List<Control>();
        static List<Control> Sources = new List<Control>();
        static public void RegisterSource(Control ctl)
        {
            if (!Sources.Contains(ctl) ) 
            {
                Sources.Add(ctl);
                ctl.MouseDown += ctl_MouseDown;
            }
        }
        static public void UnregisterSource(Control ctl)
        {
            if (Sources.Contains(ctl))
            {
                Sources.Remove(ctl);
            }
        }
        static public void RegisterTarget(Control ctl)
        {
            if (!Targets.Contains(ctl))
            {
                Targets.Add(ctl);
                ctl.DragEnter += ctl_DragEnter;
                ctl.DragDrop += ctl_DragDrop;
                ctl.AllowDrop = true;
            }
        }
        static public void UnregisterTarget(Control ctl)
        {
            if (Targets.Contains(ctl))
            {
                Targets.Remove(ctl);
                ctl.DragEnter -= ctl_DragEnter;
                ctl.DragDrop -= ctl_DragDrop;
            }
        }
        static void ctl_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox PB = sender as PictureBox;
            if (PB != null) PB.DoDragDrop(PB.Image, DragDropEffects.Copy);
            Panel Pan = sender as Panel;
            if (Pan != null) Pan.DoDragDrop(Pan.BackgroundImage, DragDropEffects.Copy);
        }
        static void ctl_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        static void ctl_DragDrop(object sender, DragEventArgs e)
        {
            Panel Pan = sender as Panel;
            if (Pan != null) Pan.BackgroundImage = (Image)e.Data.GetData(DataFormats.Bitmap);
            PictureBox PB = sender as PictureBox;
            if (PB != null) PB.BackgroundImage = (Image)e.Data.GetData(DataFormats.Bitmap);
        }
    }
