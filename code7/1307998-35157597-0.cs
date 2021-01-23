    private ToolTip Emergente; 
    
    private void bttCitas_MouseHover(object sender, EventArgs e)
    {
        string mSQL = @"    SELECT one, two, three
                FROM customers
                WHERE id = " + comboCliente.SelectedValue + ";";
        DataTable tablaTemp = retrieveData(mSQL);
    
        string customerText = ConvertDataTableToString(tablaTemp);
        Emergente = new System.Windows.Forms.ToolTip();
        Emergente.OwnerDraw = true; 
        Emergente.Draw += new DrawToolTipEventHandler(ToolTip_Draw);
        Emergente.AutoPopDelay = 150000;
        Emergente.InitialDelay = 500;
        Emergente.ReshowDelay = 500;
        Emergente.SetToolTip(this.bttCitas, customerText);            
    }
    
    
    void ToolTip_Draw(object sender, DrawToolTipEventArgs e)
    {
        using (e.Graphics)
        {
            Font f = new Font("Courier New", 9.0f);
            e.DrawBackground();
    
            e.DrawBorder();
            SolidBrush myBrush = new SolidBrush(GLOBALToolTipFontColor);                
            e.Graphics.DrawString(e.ToolTipText, f, myBrush, new PointF(2, 2));
        }
    }
    
    
    private void bttCitas_MouseLeave(object sender, EventArgs e)
    {
            Emergente.Dispose(); 
    }
