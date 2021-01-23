    public partial class Form1 : Form
    {
        SearchFunctions src = new SearchFunctions(); 
        public void Button_Click(object sender, EventArgs e)
        {
            List<Control> myControls = src.addControlsToMain(mySearchWord, mySize);
            foreach (Control c in myControls)
                {
                    this.Controls.Add(c);
                }
        }
    }
