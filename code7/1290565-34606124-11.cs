    public class ChangeComboBoxEnabilityMessage
    {
        public ChangeComboBoxEnabilityMessage(bool comboBoxEnabled)
        {
            ComboBoxIsEnabled = comboBoxEnabled
        }
    
        public bool ComboBoxIsEnabled
        {
            get;
            set;
        } 
    }
