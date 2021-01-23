    class ExtendedButton : Button
    {
        private ToolTip _tooltip = new ToolTip();
        public ExtendedButton()
        {
            _tooltip.Popup += new PopupEventHandler(_tooltip_Popup);
            _tooltip.SetToolTip(this, "DUMMYTEXT");
        }
        void _tooltip_Popup(object sender, PopupEventArgs e)
        {
            if (_tooltip.GetToolTip(this) != StringResources.MyLocalizedTooltipString)
                _tooltip.SetToolTip(this, StringResources.MyLocalizedTooltipString);
        }
    }
