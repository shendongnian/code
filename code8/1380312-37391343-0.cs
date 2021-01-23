    class vmColorPicker : ViewModelBase
        {
            private readonly ReadOnlyCollection<FontColor> roFontColors;
            private bool selectedCanBeSet = false;
    
            public vmColorPicker()
            {
                this.SelectedFontColor = AvailableColors.GetFontColor(Colors.Black);
                this.roFontColors = new ReadOnlyCollection<FontColor>(new AvailableColors());
            }
    
            public ReadOnlyCollection<FontColor> FontColors
            {
                get { return this.roFontColors; }
            }
    
    
            public bool SelectedCanBeSet
            {
                get { return selectedCanBeSet; }
                set { selectedCanBeSet = value; }
            }
    
            private FontColor selectedFontColor;
            public FontColor SelectedFontColor
            {
                get
                {
                    return this.selectedFontColor;
                }
    
                set
                {
                    if (this.selectedFontColor == value) return;
    
                    this.selectedFontColor = value;
                    SetProperty(ref this.selectedFontColor, value, "SelectedFontColor");
                }
            }
    
            #region INotifyPropertyChanged Members
    
            private void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            #endregion
        }
