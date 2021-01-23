        private ITerminalContext[] terminalContexts = new ITerminalContext[]
        {
            new Terminal0Context(this),
            new Terminal1Context(this),
            ...
        };
        public void comboBox_SelectedChanged(object sender, EventArgs args)
        {
            var comboBox = (ComboBox)sender;
            this.currentTerminalContext = this.terminalContexts[comboBox.SelectedIndex];
        }
