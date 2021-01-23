    private Dictionary<string, bool> _states = new Dictionary<string, bool>();
    private void toggleBtn_Click(object sender, RibbonControlEventArgs e)
    {  
      MailItem ml;
      // get current MailItem
      // something like: MailItem ml = popupWindow.GetMail
      
      // default false
      if (!(_states.Keys.Contains(ml.EntryId))){
          _states[ml.EntryId] = false;
      }
      
      // toggle the state
      _states[ml.EntryId] = !_states[ml.EntryId];
      
    }
