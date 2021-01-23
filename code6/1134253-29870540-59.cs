    /// <summary>
    /// This represents your UI in technology-independent manner
    /// </summary>
    public interface ITerminalView
    {
        String Title { get; set; }
        String Input { get; set; }
        String Output { get; set; }
        String Button1_Text { get; set; }
        String Button2_Text { get; set; }
        IEnumerable<String> SelectionItems { get; set; }
        void Clear();
    }
    public partial class MainForm : Form,
        ITerminalView
    {
        ...
        #region ITerminalView implementation
        public string Title
        {
            get { return this.Text; }
            set { this.Text = value; }
        }
        public String Button1_Text
        {
            get { return this.button1.Text; }
            set { this.button1.Text = value; }
        }
        public String Button2_Text
        {
            get { return this.button2.Text; }
            set { this.button2.Text = value; }
        }
        public string Input
        {
            get { return this.textBox_Input.Text; }
            set { this.textBox_Input.Text = value; }
        }
        public string Output
        {
            get { return this.textBox_Output.Text; }
            set { this.textBox_Output.Text = value; }
        }
        public IEnumerable<string> SelectionItems
        {
            get { return this.comboBox.Items.Cast<String>(); }
            set
            { 
                this.comboBox.Items.Clear();
                if (value == null)
                    return;
                foreach (var item in value)
                {
                    this.comboBox.Items.Add(item);
                }
            }
        }
        public void Clear()
        {
            this.comboBox.SelectedIndex = -1;
            this.Title = String.Empty;
            this.Input = String.Empty;
            this.Output = String.Empty;
            this.SelectionItems = null;
        }
        #endregion
