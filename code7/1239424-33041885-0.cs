    /// <summary>
    /// Set visibility of specified by name RenderingExtension to setted value
    /// For example, name of Excel (.xls) extension is "Excel"
    /// </summary>
    /// <param name="reportViewer">Instance of ReportViewer control</param>
    /// <param name="extensionName">Extension name (for example: "Excel")</param>
    /// <param name="visible">Visibility</param>
    private void SetVisibilityOnRenderingExtension(ReportViewer reportViewer, string extensionName, bool visible)
    {
        var renderingExtension = reportViewer.LocalReport.ListRenderingExtensions().FirstOrDefault(e => e.Name == extensionName);
        if (renderingExtension != null)
        {
            FieldInfo info = renderingExtension.GetType().GetField("m_isVisible", BindingFlags.NonPublic | BindingFlags.Instance);
            if (info != null)
            {
                info.SetValue(renderingExtension, visible);
            }
        }
    }
