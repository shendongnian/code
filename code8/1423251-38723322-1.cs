    public partial class Form1 : Form
    {
        void SubscribeToConditionChanged()
        {
            myUserControl.ConditionChanged += ShowDlg;
        }
        void ShowDlg(bool condition)
        {
            MessageBox.Show("....");
        }
    }
