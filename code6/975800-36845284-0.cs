    UIApplication m_pUIApp;
    System.Drawing.Point m_pt1, m_pt2 = System.Drawing.Point.Empty
    void DrawTask()
    {
        while (m_bDrawing == true)
        {
            m_pt2 = Cursor.Position;
            if (m_pt2.X < m_pUIApp.DrawingAreaExtents.Left + 2 ||
                m_pt2.X > m_pUIApp.DrawingAreaExtents.Right - 20 ||
                m_pt2.Y > m_pUIApp.DrawingAreaExtents.Bottom - 20 ||
                m_pt2.Y < m_pUIApp.DrawingAreaExtents.Top + 2)
            {
                System.Threading.Thread.Sleep(20);
                continue;
            }
            if (m_pt1 != System.Drawing.Point.Empty)
                using (Graphics g = Graphics.FromHwnd(IntPtr.Zero))
                {
                    g.DrawLine(Pens.Black, m_pt1, m_pt2);
                }
            System.Threading.Thread.Sleep(20);
        }
    }
