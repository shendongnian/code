    public void RestoreState(Dictionary<string, object> controlStates, 
                             Dictionary<string, object> membersStates)
    {
        InternalRestoreControls(controlStates);
        InternalRestoreMembers(membersStates);
    }
    
    private void InternalRestoreControls(Dictionary<string, object> states)
    {
        foreach (var state in states)
        {
            Control c = this.Controls.Find(state.Key, true).FirstOrDefault();
    
            if (c is TextBox)
            {
                (c as TextBox).Text = state.Value == null ? null : state.Value.ToString();
            }
            else if (c is CheckBox)
            {
                (c as CheckBox).Checked = Convert.ToBoolean(state.Value);
            }
        }
    }
    
    private void InternalRestoreMembers(Dictionary<string, object> membersStates)
    {
        // you might need to tweak this a little bit based on public/instance/static/private
        // but this is not the point of your question
        var props = this.GetType().GetProperties();
        var members = this.GetType().GetMembers();
        var fields = this.GetType().GetFields();
    
        foreach(var variable in membersStates)
        {
            var prop = props.FirstOrDefault(x => x.Name == variable.Key);
    
            if(prop != null)
            {
                prop.SetValue(this, variable.Key);
            }
        }
    }
    
    private Dictionary<string, object> GetControlsState()
    {
        return new Dictionary<string, object>()
        {
            { txtBox1.Name, txtBox1.Text },
            // continue to the rest
        };
    }
    
    private Dictionary<string, object> GetMembersState()
    {
        return new Dictionary<string, object>()
        {
            { nameof(variable1), variable1 },
            // continue to the rest
        };
    }
