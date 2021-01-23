            chart1.ChartAreas[0].AxisX.Minimum = m_objGridSetting.StartPoint_X;
            chart1.ChartAreas[0].AxisX.MajorGrid.Interval = m_objGridSetting.Specing_Dx;
            chart1.ChartAreas[0].AxisX.Interval =  m_objGridSetting.Specing_Dx;
            chart1.ChartAreas[0].AxisY.Minimum = m_objGridSetting.Startpoint_Y;
            chart1.ChartAreas[0].AxisY.MajorGrid.Interval = m_objGridSetting.Specing_Dy;
            chart1.ChartAreas[0].AxisY.Interval = m_objGridSetting.Specing_Dy;
            m_objGraphRoot.lstAxis.Sort();
            chart1.DataSource = m_objGraphRoot.lstAxis;
            chart1.DataBind();
