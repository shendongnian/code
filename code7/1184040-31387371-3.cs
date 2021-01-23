    public static class FormExtender
    {
        public static void SendFeedback(this Form frm, int nStep)
       {
           //do what must be done
           //you can call this anyhere using, for instance: m_frmParent.SendFeedback(nStep)
           //when you call it like that, m_frmParent will be given to this function as the argument frm
       }
    }
