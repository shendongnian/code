    class SheathingContext : ITypeDescriptorContext
    {
        public List<Sheathing> AvailableSheathings 
        {
            get { return SettingsController.AvailableSheathings; }
        }
    }
