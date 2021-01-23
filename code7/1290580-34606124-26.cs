    public class ChangeComboBoxEnabilityMessage : MessageBase
    {
        public ChangeComboBoxEnabilityMessage(bool comboBoxEnabled)
        {
            ComboBoxIsEnabled = comboBoxEnabled;
        }
    
        public bool ComboBoxIsEnabled
        {
            get;
            set;
        } 
    }
