	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			for (int i = 0; i < 10; i++)
			{
				ComboBoxPair pair = new ComboBoxPair(i*20);
				InitializeComboBoxPair(pair);
			}
		}
		private void InitializeComboBoxPair(ComboBoxPair comboBoxPair)
		{
			Controls.Add(comboBoxPair.ColumnSchedule);
			Controls.Add(comboBoxPair.BeamSchedule);
		}
	}
	public class ComboBoxPair
	{
		public ComboBox ColumnSchedule { get; private set; }
		public ComboBox BeamSchedule { get; private set; }
		public ComboBoxPair(int top)
		{
			ColumnSchedule = new ComboBox();
			ColumnSchedule.Top = top;
			ColumnSchedule.Items.AddRange("ABCDE".Cast<object>().ToArray());
			ColumnSchedule.SelectedIndexChanged += ColumnSchedule_SelectedIndexChanged;
			BeamSchedule = new ComboBox();
			BeamSchedule.Top = top;
			BeamSchedule.Items.AddRange("ABCDE".Select(c => string.Format("{0}{0}",c)).ToArray());
			BeamSchedule.Left = ColumnSchedule.Right;
			BeamSchedule.Visible = false;
		}
		private void ColumnSchedule_SelectedIndexChanged(object sender, EventArgs e)
		{
			BeamSchedule.Visible = ColumnSchedule.SelectedIndex > -1;
		}
	}
