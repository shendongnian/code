    object varFalse = false;
    object missing = System.Type.Missing;
    if (m_wordDoc != null)
    {
        ((Microsoft.Office.Interop.Word.Document)m_wordDoc).Close(ref varFalse, ref missing, ref missing);
        m_wordDoc = null;
    }
    if (m_wordApp != null)
    {
        ((Microsoft.Office.Interop.Word.Application)m_wordApp).Quit(ref varFalse, ref missing, ref missing);
        m_wordApp = null;
    }
