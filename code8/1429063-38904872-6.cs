        Timer cursTimer = new Timer();
        void cursTimer_Tick(object sender, EventArgs e)
        {
            int cp = txtExpresion.GetCharIndexFromPosition(
                     txtExpresion.PointToClient(Control.MousePosition));
            txtExpresion.SelectionStart = cp;
            txtExpresion.SelectionLength = 0; 
            txtExpresion.Refresh();
        }
