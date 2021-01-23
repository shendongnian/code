    namespace csDinger3
    {
        public class Program
        {
            static ClientUI aForm;
            static void Main()
            {
                 aForm = new ClientUI();
                 aForm.Show();
            }
            // Some code that's not relevant
            public static void updateText(Int32 number)
            {
                aForm.setlblStarted_txt(number.ToString());
            }
    
    public partial class ClientUI : Form
    {
        public void setlblStarted_txt(string text)
        {
            if (lblStarted.InvokeRequired)
            {
                Invoke(new EventHandler(delegate
                {
                    lblStarted.Text = text
                }));
            }
            else
            {
                lblStarted.Text = text;
            }
        }
