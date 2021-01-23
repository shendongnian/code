    private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
            {
                // Restore values stored in session state.
                if (e.PageState != null && e.PageState.ContainsKey("greetingOutputText"))
                {
                    greetingOutput.Text = e.PageState["greetingOutputText"].ToString();
                }
            }
 
    private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
            {
                e.PageState["greetingOutputText"] = greetingOutput.Text;
    
            }
