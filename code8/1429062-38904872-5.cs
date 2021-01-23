        private void txtExpresion_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(string)))
            {
                e.Effect = DragDropEffects.Copy;
                txtExpresion.Focus();
                cursTimer = new Timer();
                cursTimer.Interval = 25;
                cursTimer.Tick += cursTimer_Tick;
                cursTimer.Start();
            }
        }
        private void txtExpresion_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(System.String)))
            {
                cursTimer.Stop();
                string Item = (System.String)e.Data.GetData(typeof(System.String));
                string[] split = Item.Split(':');
               
                txtExpresion.SelectedText = split[1]
            }
        }
