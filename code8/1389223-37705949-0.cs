    public partial class DgvForm : Form
    {
        private string xml = 
    @"<?xml version='1.0' standalone='yes'?>
    <GenioCodes>
      <Code Layer='BI' Colour='1' Value='qwerty'/>
      <Code Layer='BP' Colour='2' />
      <Code Layer='BS' Colour='3' Value='Hello'/>
      <Code Layer='C' Colour='4' />
      <Code Layer='CC' Colour='1' />
      <Code Layer='CR' Colour='1' />
    </GenioCodes>";
        DataSet m_dataSet = new DataSet();
        public DgvForm()
        {
            InitializeComponent();
            // reading xml from string
            var reader = XmlReader.Create(new StringReader(xml));            
            m_dataSet.ReadXml(reader);
            m_dataGridView.DataSource = m_dataSet.Tables[0];
            var column = m_dataGridView.Columns["Colour"];
            int idx = column.Index;
            // removing text column
            m_dataGridView.Columns.RemoveAt(idx);
            // adding comboBox column
            var cbo = new DataGridViewComboBoxColumn
            {
                Name = "Colour",
                DataPropertyName = "Colour",
            };
            // unique color codes for comboBox
            var colorCodes = m_dataSet.Tables[0].AsEnumerable()
                        .Select(r => r["Colour"])
                        .Distinct()
                        .ToList();
            cbo.DataSource = colorCodes;
            // restore column in orignal position
            m_dataGridView.Columns.Insert(idx, cbo);
            m_dataGridView.EditingControlShowing += ComboBoxShowing;
        }
<!---->
        /// <summary>
        /// Activates custom drawing in comboBoxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {            
            if (e.Control is ComboBox)
            {
                ComboBox theCB = (ComboBox)e.Control;
                theCB.DrawMode = DrawMode.OwnerDrawFixed;
                try
                {
                    theCB.DrawItem -= new DrawItemEventHandler(this.ComboItemDraw);
                }
                catch { }
                theCB.DrawItem += new DrawItemEventHandler(this.ComboItemDraw);
            }
        }
        /// <summary>
        /// Custom drawing for comboBox items
        /// </summary>
        private void ComboItemDraw(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rDraw = e.Bounds;
            rDraw.Inflate(-1, -1);
            bool bSelected = Convert.ToBoolean(e.State & DrawItemState.Selected);
            bool bValue = Convert.ToBoolean(e.State & DrawItemState.ComboBoxEdit);
            rDraw = e.Bounds;
            rDraw.Inflate(-1, -1);
            if (bSelected & !bValue)
            {
                g.FillRectangle(Brushes.LightBlue, rDraw);
                g.DrawRectangle(Pens.Blue, rDraw);
            }
            else
            {
                g.FillRectangle(Brushes.White, e.Bounds);
            }
            
            if (e.Index < 0)
                return;
            string code = ((ComboBox) sender).Items[e.Index].ToString();
            Color c = GetColorFromCode(code);
            string s = c.ToString();
            SolidBrush b = new SolidBrush(c);
            Rectangle r = new Rectangle(e.Bounds.Left + 5, e.Bounds.Top + 3, 10, 10);
            g.FillRectangle(b, r);
            g.DrawRectangle(Pens.Black, r);
            g.DrawString(s, Form.DefaultFont, Brushes.Black, e.Bounds.Left + 25, e.Bounds.Top + 1);
            b.Dispose();
        }
        /// <summary>
        /// Returns color for a given code 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private Color GetColorFromCode(string code)
        {
            switch (code)
            {
                case "1": return Color.Green;
                case "2": return Color.Cyan;
                case "3": return Color.Orange;
                case "4": return Color.Gray;
            }
            return Color.Red;
        }
    }
