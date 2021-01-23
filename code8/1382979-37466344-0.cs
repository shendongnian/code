    protected override void OnMouseDown(MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            m_bLeftButton = true;
            m_MousePosition = e.Location;
            m_MouseClick = e.Location;
            if (m_bZoomWindow)
            {
                m_Points.Clear();
                m_Points.Add(GetWorldCoordinates(e.Location));
            }
        }
        base.OnMouseDown(e);
    }
