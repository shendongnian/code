    public class Form1:Form
    {
        ListBox ProgramsListbox;
        UninstallItem unistall;
        
        public Form1(){
           InitializeComponent();
           uninstall = new UninstallItem();
           button1.Click+= button1_Click;
        }
        
        void button1_Click(object sender, EventArgs e){
            unistall.RemoveSelected(ProgramsListbox);
        }
    }
